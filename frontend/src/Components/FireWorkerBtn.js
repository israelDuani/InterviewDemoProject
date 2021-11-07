import * as React from 'react';
import Button from '@mui/material/Button';
import Stack from '@mui/material/Stack';
import { FaTrash } from "react-icons/fa";
import { useDispatch,useSelector } from "react-redux";
import { FireWorkerRequest } from './ApiRequests/HRApiRequests';


export default function FireWorkerBtn() {
  const dispatch = useDispatch();
  const baseWorkerData = useSelector((state) => state.baseWorkerData);

  // use api to fire worker, and then close the current worker modal and clear the fetched base workers
  const fireWorkerClicked = () => {
    FireWorkerRequest(baseWorkerData.ID).then(()=>{
        dispatch({type: "SET_BASE_WORKERS_LIST",payload: null,});
        dispatch({type: "SET_SHOW_WORKER_MODAL",payload: false});
    })
  }

  return (
    <> 
      <Stack direction="row" spacing={2}>
        <Button color="error" variant="contained" onClick={() => {fireWorkerClicked()}}>
          <FaTrash/>
        </Button>
      </Stack>
    </>
  );
}