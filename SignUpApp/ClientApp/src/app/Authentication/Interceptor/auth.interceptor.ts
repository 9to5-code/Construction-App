import { HttpErrorResponse, HttpInterceptorFn, HttpResponse } from '@angular/common/http';
import { catchError, tap, throwError } from 'rxjs';
import { Globalcurrentuser } from 'src/app/global/global-current-user';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  
  let accessToken = localStorage.getItem("accesstoken");
 
const starttime = Date.now();
const authreq = req.clone({
  setHeaders:{
 'Content-Type': 'application/json',
    'ResponseType':'text',
    "Authorization":accessToken?`Bearer ${accessToken}`:""
  }
}
)
console.log("httprequest",authreq);//logger interceptor


return next(authreq).pipe(
tap(event =>{
  if(event instanceof HttpResponse){
   const elapsed = Date.now() - starttime
   console.log("elapsed",elapsed);

  }
}
),
catchError((error : HttpErrorResponse) => {
console.log("error occured", error);
alert("something went wrong");
return throwError(() =>error); 
}


  

)
)
  }
  
  
 // return next(req);
