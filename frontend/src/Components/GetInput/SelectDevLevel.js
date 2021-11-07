import * as React from 'react';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
import { DeveloperLevel } from '../../Constants/Constants';
import { useIntl } from "react-intl";


export default function SelectDevLevel(props) {
  const intl = useIntl();
  const varient  = props.isEnabled ? "outlined" : "filled";

  const handleChange = (event) => {
    props.setDevLevel(event.target.value);
  };


  return (
    <div>
        <FormControl fullWidth variant={varient} disabled={!props.isEnabled} >
            <InputLabel id="demo-simple-select-label">Developer Level</InputLabel>
            <Select
                labelId="demo-simple-select-label"
                id="demo-simple-select"
                value={props.devLevel}
                label={intl.formatMessage({id: "developer_level_title"})}
                onChange={handleChange}
            >
                <MenuItem value={DeveloperLevel.Junior}>Junior</MenuItem>
                <MenuItem value={DeveloperLevel.Mid}>Mid</MenuItem>
                <MenuItem value={DeveloperLevel.Senior}>Senior</MenuItem>
                <MenuItem value={DeveloperLevel.Expert}>Expert</MenuItem>
            </Select>
        </FormControl>
    </div>
  );
}