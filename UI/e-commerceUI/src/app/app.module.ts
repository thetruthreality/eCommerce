import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { AppComponent } from "./app.component";
import { AppRoutingModule } from "./app.routing.module";
import { LoginComponent } from "../Components/Login/login.component";
import { ViewComponent } from "../Components/view/view.component";

@NgModule({
    declarations:[
        AppComponent,
        LoginComponent,
        ViewComponent
    ],
    imports :[
        BrowserModule,
        FormsModule,
        AppRoutingModule
        

    ],
    bootstrap:[AppComponent]
})
export class AppModule{}