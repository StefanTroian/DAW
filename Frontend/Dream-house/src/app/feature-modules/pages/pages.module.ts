import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { UserComponent } from './user/user.component';



@NgModule({
  declarations: [
    HomeComponent,
    UserComponent
  ],
  imports: [
    CommonModule
  ]
})
export class PagesModule { }
