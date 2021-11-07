import * as React from 'react';
import FormControl from '@mui/material/FormControl';
import Stack from '@mui/material/Stack';
import Button from '@mui/material/Button';
import { UpdateDeveloperLevelRequest } from '../ApiRequests/HRApiRequests';
import { WORKER_ROLE } from '../../Constants/Constants';
import SelectDevLevel from '../GetInput/SelectDevLevel';
import { useSelector } from "react-redux";
import { useIntl } from "react-intl";


export default function DeveloperLevelData() {
  const intl = useIntl();
  const WorkerData = useSelector((state) => state.choosenWorkerData);
  const [editMode, setEditMode] = React.useState(false);
  const [devLevel, setDevLevel] = React.useState(-1);
  const btnText = editMode ? intl.formatMessage({id: "save_title"}) : intl.formatMessage({id: "edit_title"});

  // use api to update the new level
  const updateNewDevLevel = () => {
    UpdateDeveloperLevelRequest(WorkerData.ID,devLevel)
  }

  // check if need to show developer level for this worker type
  React.useEffect(() => {
      if(IsDevLevelNeeded()){
        setDevLevel(WorkerData.ProgramingLevel)
      }
    }, [])
  
  const IsDevLevelNeeded = () => {
    var role = WorkerData.WorkerType
    if(role == WORKER_ROLE.PaidDeveloper.id || role == WORKER_ROLE.PaidTechnicalTeamLeader.id)
    {
      return true;
    }
    return false
  }

  const handleBtnClicked = () => {
    if(editMode){
        updateNewDevLevel()
    }
    setEditMode(!editMode)
  }


  return (
    <div>
        {devLevel != -1 ?
        <FormControl fullWidth>
            <Stack direction="row" spacing={2}>
                <SelectDevLevel devLevel={devLevel} setDevLevel={setDevLevel} isEnabled={editMode}/>
                <Button variant="contained" onClick={() => {handleBtnClicked()}}>{btnText}</Button>
            </Stack>
        </FormControl>
        :<></>}

    </div>
  );
}
