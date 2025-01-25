import { Routes } from '@angular/router';
import { HomeComponent } from './page/home/home.component';
import { LoginComponent } from './page/login/login.component';
import { RegisterComponent } from './page/register/register.component';
import { FlowersComponent } from './page/flowers/flowers.component';
import { QueriesComponent } from './page/queries/queries.component';
import { FlowerEditorComponent } from './page/flower-editor/flower-editor.component';

export const routes: Routes = [
  {
    path: '',
    title: 'Home',
    component: HomeComponent,
  },
  {
    path: 'login',
    title: 'Login',
    component: LoginComponent,
  },
  {
    path: 'sign-up',
    title: 'Sign-up',
    component: RegisterComponent,
  },
  {
    path: 'flowers',
    title: 'Flowers',
    component: FlowersComponent,
  },
  {
    path: 'flower-editor/:id',
    title: 'Flower editor',
    component: FlowerEditorComponent,
  },
  {
    path: 'queries',
    title: 'Queries',
    component: QueriesComponent,
  },
  {
    path: '**',
    redirectTo: ''
  }

];
