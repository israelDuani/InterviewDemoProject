import * as React from 'react';
import FormControl from '@mui/material/FormControl';
import Checkbox from '@mui/material/Checkbox';
import FormControlLabel from '@mui/material/FormControlLabel';
import { useIntl } from "react-intl";


 
export default function VolunteerCheckbox() {
  const intl = useIntl();
  const [checked, setChecked] = React.useState(false);

  const handleChange = (event) => {
    alert(intl.formatMessage({id: "alert_coming-soon"}))
  };
    
  return (
    <div>
        <FormControl >
          <FormControlLabel control={<Checkbox label="Label" checked={checked} onChange={handleChange}/>} 
              label={intl.formatMessage({id: "is_volunteer_title"})} />
        </FormControl>
    </div>
  );
}
