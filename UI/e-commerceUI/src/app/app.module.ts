import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { AppComponent } from "./app.component";
import { AppRoutingModule } from "./app.routing.module";
import { LoginComponent } from "../Components/Login/login.component";
import { ViewComponent } from "../Components/view/view.component";
import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";
import { AuthInterceptor } from "../services/AuthInterceptor";
import { ProductDetailsComponent } from "../Components/ProductDetails/productDetails.component";

@NgModule({
    declarations:[
        AppComponent,
        LoginComponent,
        ViewComponent,
        ProductDetailsComponent
    ],
    imports :[
        BrowserModule,
        FormsModule,
        AppRoutingModule,
        HttpClientModule
        

    ],
    providers:[
        { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
    ],
    bootstrap:[AppComponent]
})
export class AppModule{}