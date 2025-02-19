export class Globalcurrentuser{

static set accessToken(value:any){
console.log("set",value)
 localStorage.setItem("accesstoken",value);

}

static get accesstoken(){
  var token =  localStorage.getItem("accesstoken");
  console.log("get",token);
   return token;
}


}