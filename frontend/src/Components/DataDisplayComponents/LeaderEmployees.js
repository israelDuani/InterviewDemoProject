import * as React from 'react';
import FormControl from '@mui/material/FormControl';
import TextField from '@mui/material/TextField';
import Stack from '@mui/material/Stack';
import Button from '@mui/material/Button';
import { useDispatch,useSelector  } from "react-redux";
import { useIntl } from "react-intl";
import { FormattedMessage } from "react-intl";



export default function LeaderEmployees() {
  const intl = useIntl();
  const dispatch = useDispatch();
  const WorkerData = useSelector((state) => state.choosenWorkerData);
  const [employeeList, setEmployeeList] = React.useState(WorkerData.EmployeesId);

  
  // open the leader employee table modal and close the current worker data modal
  const onClickEditEmployees = () =>{
      dispatch({type: "SET_SHOW_LEADER_EMP_TABLE",payload: true});
      dispatch({type: "SET_SHOW_WORKER_MODAL",payload: false});
  }

  return (
    <div>
        {employeeList != null?
        <>
        <FormControl fullWidth>
            <Stack direction="row" spacing={2} mt={-1}>
                <TextField
                    id="outlined-read-only-input"
                    variant="filled"
                    label={intl.formatMessage({id: "employee_count_title"})}
                    value={employeeList.length}
                    InputProps={{readOnly: true}}
                />
               <Button variant="contained" onClick={onClickEditEmployees}><FormattedMessage id="edit_employees_title"></FormattedMessage></Button>
            </Stack>
        </FormControl>
        </>:<></>}

    </div>
  );
}
