import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { MatSidenavModule } from '@angular/material/sidenav';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeadComponent } from './components/app-header/head.component';
import { LeftPanelComponent } from './components/app-left-panel/left-panel.component';
import { ContainerComponent } from './components/app-container/container.component';
import { RouterModule, Routes } from '@angular/router';
import {
  MatNativeDateModule, MatDatepickerModule, MatIconModule, MatButtonModule, MatCheckboxModule, MatToolbarModule,
  MatCardModule, MatFormFieldModule, MatInputModule, MatRadioModule, MatListModule
} from '@angular/material';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule }   from '@angular/forms';

import { LoginComponent } from './components/login/login.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { HomeComponent } from './components/home/home.component';
import { RegisterComponent } from './components/register/register.component';

const appRoutes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: '', component: HomeComponent },
  { path: 'register', component: RegisterComponent },
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full'
  },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    HeadComponent,
    LeftPanelComponent,
    ContainerComponent,
    LoginComponent,
    PageNotFoundComponent,
    HomeComponent,
    RegisterComponent
  ],
  imports: [
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: true } // debugging purposes only
    ),
    BrowserModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCheckboxModule,
    MatToolbarModule,
    MatCardModule,
    MatIconModule,
    MatInputModule,
    MatFormFieldModule,
    MatSidenavModule,
    MatNativeDateModule,
    MatDatepickerModule,
    MatRadioModule,
    MatListModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
