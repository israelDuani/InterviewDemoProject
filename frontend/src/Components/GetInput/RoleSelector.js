import * as React from 'react';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
import { WORKER_ROLE } from '../../Constants/Constants';
import { useIntl } from "react-intl";
import { FormattedMessage } from "react-intl";



export default function RoleSelector(props) {
  const intl = useIntl();

  const handleChange = (event) => {
    props.setRole(event.target.value);
  };

  
  return (
    <div>
        <FormControl fullWidth>
            <InputLabel id="demo-simple-select-label"><FormattedMessage id="role_title"></FormattedMessage></InputLabel>
            <Select
                labelId="demo-simple-select-label"
                id="demo-simple-select"
                value={props.role}
                label="Role"
                onChange={handleChange}

            >
                <MenuItem value={WORKER_ROLE.PaidDeveloper.id}>{WORKER_ROLE.PaidDeveloper.name}</MenuItem>
                <MenuItem value={WORKER_ROLE.PaidTeamLeader.id}>{WORKER_ROLE.PaidTeamLeader.name}</MenuItem>
                <MenuItem value={WORKER_ROLE.PaidTechnicalTeamLeader.id}>{WORKER_ROLE.PaidTechnicalTeamLeader.name}</MenuItem>
                <MenuItem value={WORKER_ROLE.PaidManager.id}>{WORKER_ROLE.PaidManager.name}</MenuItem>
            </Select>
        </FormControl>
    </div>
  );
}