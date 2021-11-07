const baseSalaryUrl = 'http://localhost:33862/api/Salary'

function HandleFetchError(err){
  console.log(err)
  alert("somthing went wrong, please check logs")
}

export function PaySalaryRequest(id) 
{
    const url = `${baseSalaryUrl}/PaySalary/${id}`
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


export function ChangeSalaryRequest(id, newSalary) 
{
  console.log(id, newSalary)
    const url = `${baseSalaryUrl}/ChangeSalary/${id}/${newSalary}`
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