import { ORIENTATION_TYPE } from "../../Constants/Constants";

const initialState = {
  showLeaderEmpTable: false,
  showWorkerModal: false,
  showRegisterModal:false,
  showLeaderEmpModal:false,
  showAddEmpToLeaderModal:false,
  baseWorkersList : null,
  choosenWorkerData: null,
  baseWorkerData: null,
  siteOrientation: ORIENTATION_TYPE.ENGLISH,
  language: "en"
};

const Reducer = (state = initialState, { type, payload }) => {
  switch (type) {
    case "SET_ORIENTATION":
      return { ...state, siteOrientation: payload };
    case "SET_LANGUAGE":
      return { ...state, language: payload };
    case "SET_SHOW_LEADER_EMP_TABLE":
      return { ...state, showLeaderEmpTable: payload };
    case "SET_SHOW_WORKER_MODAL":
      return { ...state, showWorkerModal: payload };
    case "SET_SHOW_ADD_EMP_TO_LEADER_MODAL":
      return { ...state, showAddEmpToLeaderModal: payload };
    case "SET_SHOW_REGISTER_MODAL":
      return { ...state, showRegisterModal: payload };
    case "SET_CHOOSEN_WORKER_DATA":
      return { ...state, choosenWorkerData: payload };
    case "SET_BASE_WORKER_DATA":
      return { ...state, baseWorkerData: payload };
    case "SET_BASE_WORKERS_LIST":
      return { ...state, baseWorkersList: payload };
    
    default:
      return state;
  }
};

export default Reducer;