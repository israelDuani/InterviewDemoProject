import React from "react";
import { FormattedMessage } from "react-intl";
import { useDispatch,useSelector } from "react-redux";
import MenuItem from '@mui/material/MenuItem';
import Select from '@mui/material/Select';
import { ORIENTATION_TYPE, LANGUAGE_TYPE } from "../../Constants/Constants";



function LanguageBtn() {
  const dispatch = useDispatch();
  const currLanguage = useSelector((state) => state.language);
  const isRehydrated = useSelector((state) => state._persist.rehydrated);
  const [language, setLanguage] = React.useState('');
  const languageStoreValues = [[LANGUAGE_TYPE.HEBREW,ORIENTATION_TYPE.HEBREW],[LANGUAGE_TYPE.ENGLISH,ORIENTATION_TYPE.ENGLISH]]


  React.useEffect(() => {
    if(isRehydrated){
      let currentLanguage = (currLanguage == LANGUAGE_TYPE.ENGLISH ? 1 : 0);
      setLanguage(currentLanguage)
    }
  }, [isRehydrated])

  const handleChange = (event) => {
    var key = event.target.value
    setLanguage(key)
    dispatch({type: "SET_LANGUAGE",payload: languageStoreValues[key][0]});
    dispatch({type: "SET_ORIENTATION",payload: languageStoreValues[key][1]});
  };

  return (
    <>
    <Select
      value={language}
      label="Language"
      onChange={handleChange}
    >
      <MenuItem value={0}><FormattedMessage id="language-btn_hebrew"></FormattedMessage></MenuItem>
      <MenuItem value={1}><FormattedMessage id="language-btn_english"></FormattedMessage></MenuItem>
    </Select>
    </>
  );
}

export default (LanguageBtn);
