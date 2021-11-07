export const ORIENTATION_TYPE = {
    HEBREW: "rtl",
    ENGLISH: "ltr",
  };

export const LANGUAGE_TYPE = {
  HEBREW: "heb",
  ENGLISH: "en",
};

export const WORKER_ROLE = {
            Worker : {id:0,name:"Worker"},
            Leader : {id:1,name:"Leader"},
            PaidWorker : {id:2,name:"Paid Worker"},
            PaidLeader : {id:3,name:"Paid Leader"},
            PaidDeveloper : {id:4,name:"Developer"},
            PaidTeamLeader : {id:5,name:"Team Leader"},
            PaidTechnicalTeamLeader : {id:6,name:"Technical Team Leader"},
            PaidManager : {id:7,name:"Manager"},
}

export const DeveloperLevel = {
  Junior : 0,
  Mid : 1,
  Senior : 2,
  Expert : 3,
}

export const DEFAULT_REGISTER_VALUES = {
  ManagerId : '-1',
  StartingSalary : 0,
}