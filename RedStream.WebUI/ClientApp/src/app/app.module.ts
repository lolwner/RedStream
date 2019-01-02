import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { MatButtonModule, MatCheckboxModule } from '@angular/material';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSidenavModule } from '@angular/material/sidenav';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeadComponent } from './Components/app-header/head.component';
import { LeftPanelComponent } from './Components/app-left-panel/left-panel.component';
import { ContainerComponent } from './Components/app-container/container.component';

@NgModule({
  declarations: [
    AppComponent,
    HeadComponent,
    LeftPanelComponent,
    ContainerComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCheckboxModule,
    MatInputModule,
    MatFormFieldModule,
    MatSidenavModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
