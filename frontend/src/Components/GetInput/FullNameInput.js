import * as React from 'react';
import FormControl from '@mui/material/FormControl';
import TextField from '@mui/material/TextField';
import Stack from '@mui/material/Stack';
import { useIntl } from "react-intl";


export default function FullNameInput(props) {
  const intl = useIntl();

  const handleFirstNameChange = (event) => {
    props.setFirstName(event.target.value);
  };
    
  const handleLastNameChange = (event) => {
    props.setLastName(event.target.value);
  };

  
  return (
    <div>
        <FormControl fullWidth>
            <Stack direction="row" spacing={2}>
                <TextField value={props.firstName} onChange={handleFirstNameChange} id="outlined-basic" label={intl.formatMessage({id: "first-name_title"})} variant="outlined" />
                <TextField value={props.fastName} onChange={handleLastNameChange} id="outlined-basic" label={intl.formatMessage({id: "last-name_title"})} variant="outlined" />
            </Stack>
        </FormControl>

    </div>
  );
}
