import * as React from 'react';
import ToggleButton from '@mui/material/ToggleButton';
import ToggleButtonGroup from '@mui/material/ToggleButtonGroup';
import { FormattedMessage } from "react-intl";


export default function DBToggle() {
  const [alignment, setAlignment] = React.useState('web');

  // switch between the 2 db sources mode
  const handleChange = (event, newAlignment) => {
    if (newAlignment !== null) {
        setAlignment(newAlignment);
      }
  };

  return (
    <ToggleButtonGroup
      disabled
      color="primary"
      value={alignment}
      exclusive
      onChange={handleChange}
    >
      <ToggleButton value="mongo"><FormattedMessage id="db-type_mongo"></FormattedMessage></ToggleButton>
      <ToggleButton value="mysql"><FormattedMessage id="db-type_mysql"></FormattedMessage></ToggleButton>
    </ToggleButtonGroup>
  );
}