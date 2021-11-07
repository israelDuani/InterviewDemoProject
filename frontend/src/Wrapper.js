import React, {useState} from 'react';
import {IntlProvider} from 'react-intl';
import English from './Languages/eng.json';
import Hebrew from './Languages/heb.json';
import { useSelector } from "react-redux";
import { useEffect } from "react";
import { LANGUAGE_TYPE } from "./Constants/Constants";



const Wrapper = (props) => {
   const newLocale = useSelector((state) => state.language);
   const [locale, setLocale] = useState(newLocale);
   var languageVar = (newLocale == LANGUAGE_TYPE.HEBREW ? Hebrew : English);
   const [messages, setMessages] = useState(languageVar);

  
   useEffect(() => {
    switch(newLocale)
    {
        case(LANGUAGE_TYPE.English):
            languageVar = English;
            break;
        case(LANGUAGE_TYPE.HEBREW):
            languageVar = Hebrew;
            break;
        default:
    }

    setMessages(languageVar)
    setLocale(newLocale)
    if (newLocale == LANGUAGE_TYPE.English) {
        setMessages(English);
    } else {
        if (newLocale == LANGUAGE_TYPE.HEBREW){
            setMessages(Hebrew);
        } else {
            setMessages(English);
        }
    }
   }, [newLocale]);

   return (
        <IntlProvider messages={messages} locale={locale}>
            {props.children}
        </IntlProvider>
   );
}

export default Wrapper;