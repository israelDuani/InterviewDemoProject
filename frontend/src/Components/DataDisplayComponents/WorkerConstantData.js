import * as React from 'react';
import FormControl from '@mui/material/FormControl';
import TextField from '@mui/material/TextField';
import Stack from '@mui/material/Stack';
import { WORKER_ROLE } from '../../Constants/Constants';
import { useSelector } from "react-redux";
import { useIntl } from "react-intl";


// show basic data of the selected employee
export default function WorkerConstantData() {
  const intl = useIntl();
  const WorkerData = useSelector((state) => state.choosenWorkerData);

  const getWorkerType = (workerTypeId) => {
    var result
    // convert numeric type value to the type name
    var found = Object.keys(WORKER_ROLE).find(function(layerKey) {
      return WORKER_ROLE[layerKey].id == workerTypeId;
    });
    if(found == undefined)
    {
      result = intl.formatMessage({id: "table-value_unknown-type"})
    }
    else{
      result = WORKER_ROLE[found].name
    }
    return result
  }
  
  return (
    <div>
        <FormControl fullWidth>
            <Stack direction="column" spacing={1}>
                <Stack direction="row" spacing={2}>
                    <TextField
                        id="outlined-read-only-input"
                        variant="filled"
                        label={intl.formatMessage({id: "first-name_title"})}
                        defaultValue={WorkerData.FirstName}
                        InputProps={{
                            readOnly: true,
                            }}
                    />
                    <TextField
                        id="outlined-read-only-input"
                        variant="filled"
                        label={intl.formatMessage({id: "last-name_title"})}
                        defaultValue={WorkerData.LastName}
                        InputProps={{
                            readOnly: true,
                            }}
                    />
                </Stack>
                <Stack direction="row" spacing={2}>
                    <TextField
                        id="outlined-read-only-input"
                        variant="filled"
                        label={intl.formatMessage({id: "id_title"})}
                        defaultValue={WorkerData.ID}
                        InputProps={{readOnly: true}}
                    />
                    <TextField
                        id="outlined-read-only-input"
                        variant="filled"
                        label={intl.formatMessage({id: "role_title"})}
                        defaultValue={getWorkerType(WorkerData.WorkerType)}
                        InputProps={{readOnly: true}}
                    />
                </Stack>
            </Stack>
        </FormControl>

    </div>
  );
}
