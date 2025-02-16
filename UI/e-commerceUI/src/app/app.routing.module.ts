import { RouterModule, Routes } from "@angular/router";
import { AppComponent } from "./app.component";
import { NgModule } from "@angular/core";
import { LoginComponent } from "../Components/Login/login.component";
import { ViewComponent } from "../Components/view/view.component";
import { AuthGuard } from "../services/AuthGuard";
import { ProductDetailsComponent } from "../Components/ProductDetails/productDetails.component";
import { MyCartComponent } from "../Components/Cart/Cart.component";


const routes: Routes = [
    {path:'',redirectTo:'login',pathMatch: 'full'},
    {path:'login',component:LoginComponent},
    {path:'views',component:ViewComponent,canActivate:[AuthGuard]},
    { path: "product-details/:id", component: ProductDetailsComponent },
    { path: 'myCart', component: MyCartComponent },
    
  ];
  @NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { 
  
  }