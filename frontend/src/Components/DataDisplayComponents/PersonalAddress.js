import * as React from 'react';
import FormControl from '@mui/material/FormControl';
import TextField from '@mui/material/TextField';
import Stack from '@mui/material/Stack';
import Button from '@mui/material/Button';
import { UpdatePersonalAddressRequest } from '../ApiRequests/HRApiRequests';
import { useSelector } from "react-redux";
import { useIntl } from "react-intl";


export default function PersonalAddress() {
  const intl = useIntl();
  const WorkerData = useSelector((state) => state.choosenWorkerData);
  const [editMode, setEditMode] = React.useState(false);
  const [city, setCity] = React.useState(WorkerData.PersonalAddress.City);
  const [street, setStreet] = React.useState(WorkerData.PersonalAddress.Street);
  const btnText = editMode ? intl.formatMessage({id: "save_title"}) : intl.formatMessage({id: "edit_title"});
  const txtFieldVarient  = editMode ? "outlined" : "filled";
  const inputProps = editMode ? {readOnly: false} : {readOnly: true};

  // use api to update the new address
  const updateNewAddress = () => {
    var newAddress = {City:city,Street:street}
    UpdatePersonalAddressRequest(WorkerData.ID,newAddress)
  }

  // switch the btn mode, if the button was on edit mode, the update the address
  const handleBtnClicked = () => {
    if(editMode){
        updateNewAddress()
    }
    setEditMode(!editMode)
  }

  // set state on change of the text fields
  const handleCityChange = (event) => {
    setCity(event.target.value);
  };
    
  const handleStreetChange = (event) => {
    setStreet(event.target.value);
  };


  return (
    <div>
        <FormControl fullWidth>
            <Stack direction="row" spacing={2}>
                <TextField
                    variant={txtFieldVarient}
                    label={intl.formatMessage({id: "city_title"})}
                    value={city}
                    onChange={handleCityChange}
                    InputProps={inputProps}
                />
                <TextField
                    variant={txtFieldVarient}
                    label={intl.formatMessage({id: "street_title"})}
                    value={street}
                    onChange={handleStreetChange}
                    InputProps={inputProps}
                />
                <Button variant="contained" onClick={() => {handleBtnClicked()}}>{btnText}</Button>
            </Stack>
        </FormControl>

    </div>
  );
}
