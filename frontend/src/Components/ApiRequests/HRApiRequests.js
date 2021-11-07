const baseHRUrl = 'http://localhost:33862/api/HR'

function HandleFetchError(err){
  console.log(err)
  alert("somthing went wrong, please check logs")
}

export function HireRequest(jsonForm) 
{
    fetch(`${baseHRUrl}/Hire`, {
        method: "POST",
          mode: 'no-cors',
          url: `http://localhost:33862`,
          credentials: 'include',
        body: JSON.stringify(jsonForm)
      }).then(res => {
        console.log("Request complete! response:", res);
      }).catch(err=>{HandleFetchError(err)});
}


export function GetBaseWorkersListRequest() 
{
    const url = `${baseHRUrl}/GetBaseWorkersList`
    return fetch(url)
  .then(function(response) {
    return response.json();
  }).then(function(data) {
    var jsonObj = JSON.parse(data)
    console.log(jsonObj)
    return jsonObj
  }).catch(err=>{HandleFetchError(err)});
}


export function UpdatePersonalAddressRequest(id, newAddress) 
{
    console.log(id, newAddress)
    const url = `${baseHRUrl}/UpdatePersonalAddress/${id}`
    fetch(url, {
        method: "POST",
          mode: 'no-cors',
          url: `http://localhost:33862`,
          credentials: 'include',
        body: JSON.stringify(newAddress)
      }).then(res => {
        console.log("Request complete! response:", res);
      }).catch(err=>{HandleFetchError(err)});
}


export function GetFullWorkersRequest(id) 
{
    const url = `${baseHRUrl}/GetWorkerJsonById/${id}`
    return fetch(url)
  .then(function(response) {
    return response.json();
  }).then(function(data) {
    var jsonObj = JSON.parse(data)
    return jsonObj
  }).catch(err=>{HandleFetchError(err)});
}


export function UpdateDeveloperLevelRequest(id, newLevel) 
{
    const url = `${baseHRUrl}/UpdateProgramingLevel/${id}/${newLevel}`
    fetch(url, {
        method: "POST",
          mode: 'no-cors',
          url: `http://localhost:33862`,
          credentials: 'include', 
        body: ''
      }).then(res => {
        console.log("Request complete! response:", res);
      }).catch(err=>{HandleFetchError(err)});
}


export function GetEmployeesOfMangerRequest(managerId) 
{
    const url = `${baseHRUrl}/GetEmployeesOfManger/${managerId}`
    return fetch(url)
  .then(function(response) {
    return response.json();
  }).then(function(data) {
    var jsonObj = JSON.parse(data)
    return jsonObj
  }).catch(err=>{HandleFetchError(err)});
}


export function RemoveWorkerFromLeaderRequest(data) 
{
    const url = `${baseHRUrl}/RemoveWorkerFromLeader`
    return fetch(url, {
        method: "POST",
          mode: 'no-cors',
          url: `http://localhost:33862`,
          credentials: 'include', 
        body: JSON.stringify(data)
      }).then(res => {
        console.log("Request complete! response:", res);
      }).catch(err=>{HandleFetchError(err)});
}


export function AddWorkerToLeaderRequest(data) 
{
    const url = `${baseHRUrl}/AddWorkerToLeader`
    return fetch(url, {
        method: "POST",
          mode: 'no-cors',
          url: `http://localhost:33862`,
          credentials: 'include', 
        body: JSON.stringify(data)
      }).then(res => {
        console.log("Request complete! response:", res);
      }).catch(err=>{HandleFetchError(err)});
}


export function FireWorkerRequest(workerId) 
{
    const url = `${baseHRUrl}/Fire/${workerId}`
    return fetch(url, {
        method: "POST",
          mode: 'no-cors',
          url: `http://localhost:33862`,
          credentials: 'include', 
        body: ''
      }).then(res => {
        console.log("Request complete! response:", res);
      }).catch(err=>{HandleFetchError(err)});
}