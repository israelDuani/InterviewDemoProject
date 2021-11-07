import * as React from 'react';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogTitle from '@mui/material/DialogTitle';
import Button from '@mui/material/Button';
import Stack from '@mui/material/Stack';
import WorkerConstantData from './DataDisplayComponents/WorkerConstantData';
import PersonalAddress from './DataDisplayComponents/PersonalAddress';
import WorkerSalary from './DataDisplayComponents/WorkerSalary'; 
import DeveloperLevelData from './DataDisplayComponents/DeveloperLevelData';
import { GetFullWorkersRequest } from './ApiRequests/HRApiRequests';
import LeaderEmployees from './DataDisplayComponents/LeaderEmployees'
import FireWorkerBtn from './FireWorkerBtn';
import { useDispatch,useSelector } from "react-redux";
import { FormattedMessage } from "react-intl";



export default function WorkerDataModal() {
  const dispatch = useDispatch();
  //const [isLoaded, setIsLoaded] = React.useState(false);
  const baseWorkerData = useSelector((state) => state.baseWorkerData);
  const showWorkerModal = useSelector((state) => state.showWorkerModal);
  const WorkerData = useSelector((state) => state.choosenWorkerData);

  // close the current modal
  const handleClose = () => {
    //setIsLoaded(false)
    dispatch({type: "SET_SHOW_WORKER_MODAL",payload: false});
    dispatch({type: "SET_CHOOSEN_WORKER_DATA",payload: null});

  };

  // get the full data about the selected worker
  React.useEffect(() => {
      GetFullWorkersRequest(baseWorkerData.ID).then(function(result) {
        dispatch({type: "SET_CHOOSEN_WORKER_DATA",payload: result})
        //setIsLoaded(true)
      })
    }, [showWorkerModal])

  return (
    
    <div>
    {WorkerData?
      <Dialog open={showWorkerModal} onClose={handleClose}>
        <DialogTitle><FormattedMessage id="worker_data_title"></FormattedMessage></DialogTitle>
        <DialogContent>
          <Stack direction="column" spacing={1}>
                <WorkerConstantData/>
                <PersonalAddress/>
                <WorkerSalary/>
                <DeveloperLevelData/>
                <LeaderEmployees/>
                <FireWorkerBtn/>
          </Stack>
        </DialogContent>
      </Dialog>
      :<></>}
    </div>
    
  );
}