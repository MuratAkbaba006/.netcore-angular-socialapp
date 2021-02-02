import { Component, OnInit } from '@angular/core';
import { Model } from './Model';
import { JwtHelperService } from "@auth0/angular-jwt";
import { AuthService } from './_services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  jwtHelper=new JwtHelperService();
  title = 'SocialApp';

 constructor(private authService:AuthService){}

ngOnInit(){

  const token=localStorage.getItem("token");
  if(token){
  this.authService.decodedToken=this.jwtHelper.decodeToken(token);

  }
}
}