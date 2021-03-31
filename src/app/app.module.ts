import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { AppRoutingModule } from './app-routing.module';

import { AuthGuard } from './guards/auth.guard';
import { JwtInterceptor } from './helpers/jwt-interceptor';
import { AppComponent } from './app.component';
import { SavedMessagesComponent } from './saved-messages/saved-messages.component';
import { FileMessageComponent } from './saved-messages/file-message/file-message.component';
import { TextMessageComponent } from './saved-messages/text-message/text-message.component';
import { ImgMessageComponent } from './saved-messages/img-message/img-message.component';
import { LoginComponent } from './login/login.component';
import { AuthenticationService } from './services/authentication.service';
import { CreateTextMsgComponent } from './saved-messages/create-text-msg/create-text-msg.component';
import { FileMessagesService } from './services/file-messages.service';
import { TextMessagesService } from './services/text-messages.service';

@NgModule({
  declarations: [
    AppComponent,
    SavedMessagesComponent,
    FileMessageComponent,
    TextMessageComponent,
    ImgMessageComponent,
    LoginComponent,
    CreateTextMsgComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    FontAwesomeModule,
    HttpClientModule,
    
  ],
  providers: [
    AuthGuard,
    AuthenticationService,
    FileMessagesService,
    {
        provide: HTTP_INTERCEPTORS,
        useClass: JwtInterceptor,
        multi: true

    },
    TextMessagesService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
    },
    // ImageMessagesService
    // UserService,
    // {
    //     provide: HTTP_INTERCEPTORS,
    //     useClass: JwtInterceptor,
    //     multi: true
    // },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
