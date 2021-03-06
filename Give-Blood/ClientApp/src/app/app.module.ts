import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsModalRef, ModalModule } from 'ngx-bootstrap/modal';
import { ComponentsModule } from './components/components.module';
import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { AdminLayoutModule } from './layouts/admin-layout/admin-layout.module';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { MatTooltipModule } from '@angular/material/tooltip';
import { QRCodeModule } from 'angularx-qrcode';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { IvyCarouselModule } from 'angular-responsive-carousel';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AdminLayoutComponent,
    AboutComponent,
    ContactComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ApiAuthorizationModule,
    AdminLayoutModule,
    RouterModule.forRoot([
      { path: 'login', component: HomeComponent },
      { path: 'home', component: AdminLayoutComponent, canActivate: [AuthorizeGuard]},
      { path: '', component: HomeComponent },
      { path: 'about', component: AboutComponent },
      { path: 'contact', component: ContactComponent },
      //{ path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
    ]),
    BrowserAnimationsModule,
    ModalModule.forRoot(),
    ComponentsModule,
    AngularFontAwesomeModule,
    MatTooltipModule,
    QRCodeModule,
    IvyCarouselModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent],
  exports: [AboutComponent, ContactComponent]
})
export class AppModule { }
