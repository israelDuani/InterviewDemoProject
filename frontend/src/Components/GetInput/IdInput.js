import * as React from 'react';
import FormControl from '@mui/material/FormControl';
import TextField from '@mui/material/TextField';
import { useIntl } from "react-intl";


export default function IdInput(props) {
  const intl = useIntl();

  const handleChange = (event) => {
    props.setId(event.target.value);
  };

  
  return (
    <div>
        <FormControl>
                <TextField value={props.id} onChange={handleChange} id="outlined-basic" label={intl.formatMessage({id: "id_title"})} variant="outlined" />
        </FormControl>
    </div>
  );
}
