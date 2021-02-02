import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {map} from 'rxjs/operators';
import { JwtHelperService } from "@auth0/angular-jwt";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl:string="http://localhost:5000/api/user/";

  jwtHelper=new JwtHelperService();
  decodedToken:any;



  constructor(private http:HttpClient) { }

  login(model:any){

return this.http.post(this.baseUrl+'login',model).pipe(map((response:any) =>{
const result=response;
if(result){
  localStorage.setItem("token",result.token);

}


})); //burada kullanıcı adı ve şifreyi post ettiğimizde
//bize bir token dönderir bu asenkron sorgunun cevabını almak için pipe() metodunu kulanmalıyız
//map() metodu ile bize gelen any tipindeki responseden token bilgisini aldık

  }


register(model:any){
return this.http.post(this.baseUrl+'register',model);


}

loggedIn(){

  const token=localStorage.getItem("token");
  return !this.jwtHelper.isTokenExpired(token);//süre bitmişse fonk true değer dönderin tersini alarak false yaptık

}


}
