import * as React from 'react';
import { DataGrid } from '@mui/x-data-grid';
import { FaPlusSquare } from "react-icons/fa";
import {GridActionsCellItem} from '@mui/x-data-grid';
import {  GetBaseWorkersListRequest,AddWorkerToLeaderRequest } from '../ApiRequests/HRApiRequests'
import { WORKER_ROLE } from '../../Constants/Constants';
import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogTitle from '@mui/material/DialogTitle';
import { useDispatch,useSelector  } from "react-redux";
import { useIntl } from "react-intl";
import { FormattedMessage } from "react-intl";


function compareValues(v1,v2){
  return v1.toString().localeCompare(v2.toString())
}


export default function AddEmployeeToLeader() {
  const intl = useIntl();
  const dispatch = useDispatch();
  const [unManagerdEmployees, setUnManagerdEmployees] = React.useState([])
  const WorkerData = useSelector((state) => state.choosenWorkerData);
  const showAddEmpToLeaderModal = useSelector((state) => state.showAddEmpToLeaderModal);
  const baseWorkersList = useSelector((state) => state.baseWorkersList);


  // filter the base worker list every time the base worker list is changed 
  React.useEffect(() => {
    var filteredList = baseWorkersList.filter( x => (x.ManagerId == "-1") && (x.ID != WorkerData.ID));
    setUnManagerdEmployees(filteredList)
  }, [baseWorkersList])

  // close the current modal and open the previous modal
  const handleClose = () => {
    dispatch({type: "SET_SHOW_ADD_EMP_TO_LEADER_MODAL",payload: false});
    dispatch({type: "SET_SHOW_LEADER_EMP_TABLE",payload: true});
  };

  // fetch the base workers list
  const fetchBaseWorkers = () => {
    GetBaseWorkersListRequest().then(function(result) {
      dispatch({type: "SET_BASE_WORKERS_LIST",payload: result});
      })
  }

  // add employee to leader
  const handleAddClick = (id) => (event) => {
    event.stopPropagation();
    var data = {ManagerId:WorkerData.ID,WorkerId:id}
    AddWorkerToLeaderRequest(data).then(() => {
        fetchBaseWorkers()
      })
  };

  function setWorkerType(params){
    var workerTypeId = params.row.WorkerType
    var result
    // convert numeric type value to the type name
    var found = Object.keys(WORKER_ROLE).find(function(layerKey) {
      return WORKER_ROLE[layerKey].id == workerTypeId;
    });
    if(found == undefined)
    {
      result = "Unknown Type"
    }
    else{
      result = WORKER_ROLE[found].name
    }
    return result
  }

  const columns = [
    { field: 'ID', headerName: intl.formatMessage({id: "id_title"}), width: 110 },
    { field: 'FirstName', headerName: intl.formatMessage({id: "first-name_title"}), width: 200 },
    { field: 'LastName', headerName: intl.formatMessage({id: "last-name_title"}), width: 200 },
    {
      field: 'WorkerType',
      headerName: intl.formatMessage({id: "worker-type_title"}),
      width: 160,
      valueGetter: setWorkerType, sortComparator: compareValues
    },
    {
      field: 'actions',
      type: 'actions',
      headerName: intl.formatMessage({id: "actions_title"}),
      width: 100,
      getActions: ({ id }) => {
          return [
            <GridActionsCellItem
              icon={<FaPlusSquare color="#66a6ff"/>}
              label={intl.formatMessage({id: "add_title"})}
              onClick={handleAddClick(id)}
              color="inherit"
            />,
          ];
        }
      }
  ];


  return (
    <>
    <Dialog open={showAddEmpToLeaderModal} onClose={handleClose} maxWidth={'xl'}>
        <DialogTitle><FormattedMessage id="manage_leader_employees_title"></FormattedMessage></DialogTitle>
        <DialogContent>
          <div style={{ height: 350, width: 780 }}>
              <DataGrid
                getRowId={(row) => row.ID}
                rows={unManagerdEmployees}
                columns={columns}
                pageSize={10}
                rowsPerPageOptions={[10]}
              />
          </div>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleClose}><FormattedMessage id="close_btn_title"></FormattedMessage></Button>
        </DialogActions>
      </Dialog>
    </>
  );
}