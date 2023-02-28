import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateUserComponent } from './components/create-user/create-user.component';
import { ListUserComponent } from './components/list-user/list-user.component';

const routes: Routes = [
  { path: '', component: ListUserComponent, pathMatch: 'full' },
  { path: 'create-user', component: CreateUserComponent },
  { path: 'edit-user/:id', component: CreateUserComponent },
  { path: '**', redirectTo: '', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
