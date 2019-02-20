import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { MatSidenavModule } from '@angular/material/sidenav';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { ContainerComponent } from './app-container/container.component';
import {
  MatNativeDateModule, MatDatepickerModule, MatIconModule, MatButtonModule, MatCheckboxModule, MatToolbarModule,
  MatCardModule, MatFormFieldModule, MatInputModule, MatRadioModule, MatListModule
} from '@angular/material';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';

import { LeftPanelComponent } from './app-left-panel/left-panel.component';
import { HeadComponent } from './app-header/head.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,

    LeftPanelComponent,
    HeadComponent,
    LoginComponent,
    ContainerComponent,
    PageNotFoundComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,

    MatNativeDateModule, MatDatepickerModule, MatIconModule, MatButtonModule, MatCheckboxModule, MatToolbarModule,
    MatCardModule, MatFormFieldModule, MatInputModule, MatRadioModule, MatListModule, MatSidenavModule,

    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full'
      },
      { path: '**', component: PageNotFoundComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
