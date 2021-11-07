import * as React from 'react';
import { DataGrid } from '@mui/x-data-grid';
import {  GetBaseWorkersListRequest } from './ApiRequests/HRApiRequests'
import { WORKER_ROLE } from '../Constants/Constants';
import { useDispatch,useSelector } from "react-redux";
import { useIntl } from "react-intl";


function compareValues(v1,v2){
  return v1.toString().localeCompare(v2.toString())
}

function setWorkerCity(param){
  var PersonalAddress = param.row['PersonalAddress']
  return PersonalAddress.City
}



export default function WorkersTable() {
  const intl = useIntl();
  const dispatch = useDispatch();
  const baseWorkersList = useSelector((state) => state.baseWorkersList);

  // save on store the selected worker data, and open the worker modal of the selected worker
  function currentlySelected(selected){
    dispatch({type: "SET_BASE_WORKER_DATA",payload: selected.row,});
    dispatch({type: "SET_SHOW_WORKER_MODAL",payload: true,});
  }
  
  // fetch the list of base workers
  const fetchBaseWorkers = () => {
    GetBaseWorkersListRequest().then(function(result) {
      dispatch({type: "SET_BASE_WORKERS_LIST",payload: result});
      })
  }

  // fetch again the list every time the list is null
  React.useEffect(() => {
    if(baseWorkersList == null){
      fetchBaseWorkers()
    }
  }, [baseWorkersList])

  function setManagerId(param){
    var managerId = param.row.ManagerId
    if(managerId == '-1')
    {
      managerId = intl.formatMessage({id: "table-value_no-manager"})
    }
    return managerId
  }
  
  function setWorkerType(param){
    var workerTypeId = param.row.WorkerType
    var result
    // convert numeric type value to the type name
    var found = Object.keys(WORKER_ROLE).find(function(layerKey) {
      return WORKER_ROLE[layerKey].id == workerTypeId;
    });
    if(found == undefined)
    {
      result = intl.formatMessage({id: "table-value_unknown-type"})
    }
    else{
      result = WORKER_ROLE[found].name
    }
    return result
  }
  
  const columns = [
    { field: 'ID', headerName:  intl.formatMessage({id: "id_title"}), width: 130 },
    { field: 'FirstName', headerName:  intl.formatMessage({id: "first-name_title"}), width: 200 },
    { field: 'LastName', headerName: intl.formatMessage({id: "last-name_title"}), width: 200 },
    {
      field: 'WorkerType',
      headerName: intl.formatMessage({id: "worker-type_title"}),
      width: 160,
      valueGetter: setWorkerType, sortComparator: compareValues
    },
    { field: 'City', headerName: intl.formatMessage({id: "city_title"}), width: 160, valueGetter: setWorkerCity, sortComparator: compareValues, },
    { field: 'ManagerId', headerName: intl.formatMessage({id: "manager-id_title"}), width: 160, valueGetter: setManagerId, sortComparator: compareValues},
  ];
  
  
  return (
    <>{baseWorkersList?
    <div style={{ height: 600, width: '100%' }}>
      <DataGrid
        getRowId={(row) => row.ID}
        rows={baseWorkersList}
        columns={columns}
        pageSize={10}
        rowsPerPageOptions={[10]}
        onCellClick={currentlySelected}
      />
    </div>:<></>}
    </>
  );
}