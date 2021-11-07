import * as React from 'react';
import FormControl from '@mui/material/FormControl';
import TextField from '@mui/material/TextField';
import Stack from '@mui/material/Stack';
import Button from '@mui/material/Button';
import { PaySalaryRequest, ChangeSalaryRequest } from '../ApiRequests/SalaryApiRequests';
import { useSelector } from "react-redux";
import { useIntl } from "react-intl";
import { FormattedMessage } from "react-intl";


export default function WorkerSalary() {
  const intl = useIntl();
  const WorkerData = useSelector((state) => state.choosenWorkerData);
  const [editMode, setEditMode] = React.useState(false);
  const [salary, setSalary] = React.useState(WorkerData.Salary);
  const [lastValidSalary, setLastValidSalary] = React.useState(WorkerData.Salary);
  const [totalSalary, setTotalSalary] = React.useState(WorkerData.TotalSalary);
  const [paySalaryDisabled, setPaySalaryDisabled] = React.useState(false);
  const btnText = editMode ? intl.formatMessage({id: "save_title"}) : intl.formatMessage({id: "edit_title"});
  const txtFieldVarient  = editMode ? "outlined" : "filled";
  const inputProps = editMode ? {readOnly: false} : {readOnly: true};


  // check if the salary is valid number
  const checkValidNumber = (num) =>{
    var result = false
    if(isNaN(num) == false){
        if(num >= 0){
            result = true
        }
    }
    return result
  }

  // change the current salary
  const handleSetSalaryClicked = () => {
    if(editMode){
        if(checkValidNumber(salary)){
            var intSalary = parseInt(salary)
            setLastValidSalary(salary)
            ChangeSalaryRequest(WorkerData.ID,intSalary)
        }
        else{
            setSalary(lastValidSalary)
        }
    }
    setEditMode(!editMode)
    setPaySalaryDisabled(!paySalaryDisabled)
  }

  // pay salary to the selected worker
  const handlePaySalaryClicked = () => {
    var newSalary = parseInt(totalSalary)+parseInt(salary)
    setTotalSalary(newSalary)
    PaySalaryRequest(WorkerData.ID)
  }

  const handleSalaryChange = (event) => {
      setSalary(event.target.value);
  };


  return (
    <div>
        <FormControl fullWidth>
            <Stack direction="column" spacing={1}>
                <Stack direction="row" spacing={2}>
                    <TextField
                        variant={txtFieldVarient}
                        label={intl.formatMessage({id: "salary_title"})}
                        value={salary}
                        onChange={handleSalaryChange}
                        InputProps={inputProps}
                    />
                    <Button variant="contained" onClick={() => {handleSetSalaryClicked()}}>{btnText}</Button>
                </Stack>
                <Stack direction="row" spacing={2}>
                    <TextField
                        variant='filled'
                        label={intl.formatMessage({id: "total_salary_title"})}
                        value={totalSalary}
                        InputProps={{readOnly: true}}
                    />
                    <Button disabled={paySalaryDisabled} variant="contained" onClick={() => {handlePaySalaryClicked()}}>
                        <FormattedMessage id="pay_salary_btn_title"></FormattedMessage>
                    </Button>
                </Stack>
            </Stack>
        </FormControl>

    </div>
  );
}
