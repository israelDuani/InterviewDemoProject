import * as React from 'react';
import { useDispatch,useSelector  } from "react-redux";
import { DataGrid } from '@mui/x-data-grid';
import { FaTrash } from "react-icons/fa";
import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogTitle from '@mui/material/DialogTitle';
import TextField from '@mui/material/TextField';
import {GridActionsCellItem} from '@mui/x-data-grid';
import {  GetEmployeesOfMangerRequest,RemoveWorkerFromLeaderRequest } from '../ApiRequests/HRApiRequests'
import { WORKER_ROLE } from '../../Constants/Constants';
import { useIntl } from "react-intl";
import { FormattedMessage } from "react-intl";


function compareValues(v1,v2){
  return v1.toString().localeCompare(v2.toString())
}


export default function LeaderEmployeesTable() {
  const intl = useIntl();
  const dispatch = useDispatch();
  const [empList, setEmpList] = React.useState([])
  const WorkerData = useSelector((state) => state.choosenWorkerData);
  const showLeaderEmpTable = useSelector((state) => state.showLeaderEmpTable);

  // fetch the employees of the selected leader
  const fetchEmpList = () =>{
    GetEmployeesOfMangerRequest(WorkerData.ID).then(function(result) {
      setEmpList(result)
    })
  }

  // fetch the employees of the selected leader every time the employee table is opened 
  React.useEffect(() => {
    fetchEmpList()
  }, [showLeaderEmpTable])

  // close the current modal, and open the previos modal
  const handleClose = () => {
    dispatch({type: "SET_SHOW_LEADER_EMP_TABLE",payload: false});
    dispatch({type: "SET_SHOW_WORKER_MODAL",payload: true});
  };

  // remove the selected employee from the selected leader
  const handleDeleteClick = (id) => (event) => {
    event.stopPropagation();
    var data = {ManagerId:WorkerData.ID,WorkerId:id}
    RemoveWorkerFromLeaderRequest(data).then(() => {
      fetchEmpList()
      dispatch({type: "SET_BASE_WORKERS_LIST",payload: null,});
    })
    
  };
  
  // open the modal that allow to add new employee to the selected leader, and close the current modal
  const handleShowAddWorkerToLeaderModal = () =>{
    dispatch({type: "SET_SHOW_ADD_EMP_TO_LEADER_MODAL",payload: true,})
    dispatch({type: "SET_SHOW_LEADER_EMP_TABLE",payload: false,})
  }

  const setWorkerType = (params) => {
    var workerTypeId = params.row.WorkerType
    var result
    // convert numeric type value to the type name
    var found = Object.keys(WORKER_ROLE).find(function(layerKey) {
      return WORKER_ROLE[layerKey].id == workerTypeId;
    });
    if(found == undefined)
    {
      result =  intl.formatMessage({id: "table-value_unknown-type"})
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
              icon={<FaTrash />}
              label={intl.formatMessage({id: "delete_title"})}
              onClick={handleDeleteClick(id)}
              color="inherit"
            />,
          ];
        }
      }
  ];


  return (
    <>
    <Dialog open={showLeaderEmpTable} onClose={handleClose} maxWidth={'xl'}>
        <DialogTitle><FormattedMessage id="manage_leader_employees_title"></FormattedMessage></DialogTitle>
        <DialogContent>
            <TextField
                id="outlined-read-only-input"
                variant="filled"
                label={intl.formatMessage({id: "leader_name_title"})}
                value={WorkerData.FirstName + ' ' + WorkerData.LastName}
                InputProps={{readOnly: true}}
            />
            <Button variant="contained" onClick={() => {handleShowAddWorkerToLeaderModal()}}>
              +
            </Button>
            <div style={{ height: 350, width: 780 }}>
                <DataGrid
                getRowId={(row) => row.ID}
                rows={empList}
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