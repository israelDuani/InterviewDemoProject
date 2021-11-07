import * as React from 'react';
import FormControl from '@mui/material/FormControl';
import TextField from '@mui/material/TextField';

export default function SalaryInput(props) {
  const handleSalaryChange = (event) => {
    props.setSalary(event.target.value);
  };
    
  
  return (
    <div>
        <FormControl >
                <TextField type='number' value={props.salary} onChange={handleSalaryChange} id="outlined-basic" variant="outlined" />
        </FormControl>
    </div>
  );
}
