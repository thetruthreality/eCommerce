import { RouterModule, Routes } from "@angular/router";
import { AppComponent } from "./app.component";
import { NgModule } from "@angular/core";
import { LoginComponent } from "../Components/Login/login.component";
import { ViewComponent } from "../Components/view/view.component";

const routes: Routes = [
    {path:'',redirectTo:'login',pathMatch: 'full'},
    {path:'login',component:LoginComponent},
    {path:'views',component:ViewComponent}
    
  ];
  @NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { 
  
  }