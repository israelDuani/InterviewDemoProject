import * as React from 'react';
import Button from '@mui/material/Button';
import Stack from '@mui/material/Stack';
import RegisterWorkerModal from './RegisterWorkerModal';
import { useDispatch } from "react-redux";


export default function AddWorkerBtn() {
  const dispatch = useDispatch();
  const [openRegisterModal, setOpenRegisterModal] = React.useState(false);

  // open register modal
  const openRegisterModalBtnClicked = () =>{
    dispatch({type: "SET_SHOW_REGISTER_MODAL",payload: true})
  }

  return (
    <>
      <RegisterWorkerModal isOpen = {openRegisterModal} SetIsOpen = {setOpenRegisterModal}/>
      <Stack direction="row" spacing={2}>
        <Button variant="contained" onClick={() => {openRegisterModalBtnClicked()}}>
          +
        </Button>
      </Stack>
    </>
  );
}