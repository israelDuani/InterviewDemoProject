import * as React from 'react';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogTitle from '@mui/material/DialogTitle';
import Button from '@mui/material/Button';
import Stack from '@mui/material/Stack';
import { useDispatch,useSelector } from "react-redux";
import { DEFAULT_REGISTER_VALUES,WORKER_ROLE } from '../Constants/Constants';
import { HireRequest } from './ApiRequests/HRApiRequests'
import IdInput from './GetInput/IdInput';
import RoleSelector from './GetInput/RoleSelector';
import FullNameInput from './GetInput/FullNameInput';
import AddressInput from './GetInput/AddressInput';
import SalaryInput from './GetInput/SalaryInput';
import VolunteerCheckbox from './GetInput/VolunteerCheckbox';
import SelectDevLevel from './GetInput/SelectDevLevel';
import { useIntl } from "react-intl";
import { FormattedMessage } from "react-intl";



export default function RegisterWorkerModal() {
  const intl = useIntl();
  const dispatch = useDispatch();
  const showRegisterModal = useSelector((state) => state.showRegisterModal);
  const [id, setId] = React.useState('');
  const [role, setRole] = React.useState(-1);
  const [devLevel, setDevLevel] = React.useState(-1);
  const [firstName, setFirstName] = React.useState('');
  const [lastName, setLastName] = React.useState('');
  const [city, setCity] = React.useState('');
  const [street, setStreet] = React.useState('');
  const [salary, setSalary] = React.useState(0);


  // check if need a developer level for the selected worker type
  const IsDevLevelNeeded = (userRole) => {
    if(userRole == WORKER_ROLE.PaidDeveloper.id || userRole == WORKER_ROLE.PaidTechnicalTeamLeader.id)
    {
      return true;
    }
    return false
  }

  // check if the form is valid and have no missing fields
  const isValid = () => {
    var result = false;
    if(id && (role >= 0) &&firstName && lastName && city && street){
      if(IsDevLevelNeeded(role))
      {
        result = (devLevel >= 0) ? true : false;
      }
      else
      {
        result = true;
      }
    }
    return result;
  }
  
  // send the form to the server if the form is valid and then refetch the base workers list
  const handleSendForm = () => {
    if(isValid()){
      const jsonForm = {ID:id,FirstName:firstName,LastName:lastName,ManagerId:DEFAULT_REGISTER_VALUES.ManagerId,WorkerType:role,PersonalAddress:{City:city,Street:street},Salary:parseInt(salary, 10),TotalSalary:DEFAULT_REGISTER_VALUES.StartingSalary}
      if(IsDevLevelNeeded(role)){
        jsonForm['ProgramingLevl'] = devLevel
      }
      HireRequest(jsonForm)
      dispatch({type: "SET_BASE_WORKERS_LIST",payload: null,});
      handleClose()
    }
    else{
      alert(intl.formatMessage({id: "alert_register_fill-all-fields"}))
    }
  }

  // clear all the fields after close
  const handleClose = () => {
    setId('')
    setRole(-1)
    setDevLevel(-1)
    setFirstName('')
    setLastName('')
    setCity('')
    setStreet('')
    setSalary(0)
    dispatch({type: "SET_SHOW_REGISTER_MODAL",payload: false,})
  };


  return (
    <div>
      <Dialog open={showRegisterModal} onClose={handleClose}>
        <DialogTitle><FormattedMessage id="register_worker_title"></FormattedMessage></DialogTitle>
        <DialogContent>
          <Stack direction="column" spacing={2} mt={2}>
              <RoleSelector role={role} setRole={setRole} />
              {IsDevLevelNeeded(role) ? <SelectDevLevel devLevel={devLevel} setDevLevel={setDevLevel} isEnabled={true}/> : <></>}
              <Stack direction="row" spacing={2}>
                <IdInput id={id} setId={setId} />
                <SalaryInput salary={salary} setSalary={setSalary}/>
              </Stack>
                <FullNameInput firstName={firstName} lastName={lastName} setFirstName={setFirstName} setLastName={setLastName}/>
                <AddressInput city={city} street={street} setCity={setCity} setStreet={setStreet}/>
              <VolunteerCheckbox/>
          </Stack>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleClose}><FormattedMessage id="cancel_btn_title"></FormattedMessage></Button>
          <Button onClick={handleSendForm}><FormattedMessage id="register_btn_title"></FormattedMessage></Button>
        </DialogActions>
      </Dialog>
    </div>
  );
}