import * as React from 'react';
import FormControl from '@mui/material/FormControl';
import TextField from '@mui/material/TextField';
import Stack from '@mui/material/Stack';
import { useIntl } from "react-intl";


export default function AddressInput(props) {
  const intl = useIntl();

  const handleCityChange = (event) => {
    props.setCity(event.target.value);
  };
    
  const handleStreetChange = (event) => {
    props.setStreet(event.target.value);
  };

  
  return (
    <div>
        <FormControl fullWidth>
            <Stack direction="row" spacing={2}>
                <TextField value={props.city} onChange={handleCityChange} id="outlined-basic" label={intl.formatMessage({id: "city_title"})} variant="outlined" />
                <TextField value={props.street} onChange={handleStreetChange} id="outlined-basic" label={intl.formatMessage({id: "street_title"})} variant="outlined" />
            </Stack>
        </FormControl>
    </div>
  );
}
