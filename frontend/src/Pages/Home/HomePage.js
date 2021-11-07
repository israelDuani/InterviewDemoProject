import React,{ useEffect } from 'react';
import { FormattedMessage } from "react-intl";
import { useIntl } from "react-intl";

import DBToggle from '../../Components/DBToggle';
import AddWorkerBtn from '../../Components/AddWorkerBtn';
import WorkersTable from '../../Components/WorkersTable';
import Stack from '@mui/material/Stack';
import { useDispatch,useSelector } from "react-redux";
import WorkerDataModal from '../../Components/WorkerModal'
import LeaderEmployeesTable from '../../Components/DataDisplayComponents/LeaderEmployeesTable';
import AddEmployeeToLeader from '../../Components/DataDisplayComponents/AddEmployeeToLeader';
import LanguageBtn from '../../Components/Languages/LanguageBtn';


function HomePage() {
  const dispatch = useDispatch();
  // used to conditionally show modals
  const showLeaderEmpTable = useSelector((state) => state.showLeaderEmpTable);
  const showWorkerModal = useSelector((state) => state.showWorkerModal);
  const showLeaderEmpModal = useSelector((state) => state.showLeaderEmpModal);
  const showAddEmpToLeaderModal = useSelector((state) => state.showAddEmpToLeaderModal);
  const isRehydrated = useSelector((state) => state._persist.rehydrated);

  // const siteOrientation = useSelector((state) => state.siteOrientation);
  // const finalDescription = (siteOrientation === ORIENTATION_TYPE.ENGLISH) ? description : descriptionHeb
  // <FormattedMessage id="home__first_section_family_link"></FormattedMessage>

 
  // clear selected data after refresh
  React.useEffect(() => {
    if(isRehydrated){
      dispatch({type: "SET_SHOW_LEADER_EMP_TABLE",payload: false,});
      dispatch({type: "SET_SHOW_WORKER_MODAL",payload: false,});
      dispatch({type: "SET_SHOW_REGISTER_MODAL",payload: false,});
      dispatch({type: "SET_SHOW_ADD_EMP_TO_LEADER_MODAL",payload: false,});
      dispatch({type: "SET_CHOOSEN_WORKER_DATA",payload: null,});
      dispatch({type: "SET_BASE_WORKER_DATA",payload: null,});
      dispatch({type: "SET_BASE_WORKERS_LIST",payload: null,});
    }
    }, [isRehydrated])

  return (
    <div style={{margin:'15px'}}>
      {showLeaderEmpTable?<LeaderEmployeesTable/>:<></>}
      {showWorkerModal?<WorkerDataModal/>:<></>}
      {showLeaderEmpModal?<LeaderEmployeesTable/>:<></>}
      {showAddEmpToLeaderModal?<AddEmployeeToLeader/>:<></>}
      <Stack direction="column" spacing={2}>
        <Stack direction="row" spacing={2}>
          <AddWorkerBtn/>
          <DBToggle/>
          <LanguageBtn/>
        </Stack>
        <Stack direction="row" spacing={2}>
          <WorkersTable/>
        </Stack>
      </Stack>
    </div>
  );
}

export default HomePage;
