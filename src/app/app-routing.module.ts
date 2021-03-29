import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';
import { LoginComponent } from './login/login.component';
import { SavedMessagesComponent } from './saved-messages/saved-messages.component';

const routes: Routes = [
  { path: '', component: SavedMessagesComponent, canActivate: [AuthGuard]},
  { path: 'login', component: LoginComponent },
  { path: 'saved-messages', component: SavedMessagesComponent, canActivate: [AuthGuard]},

  //otherwise redirect to SavedMessages
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
