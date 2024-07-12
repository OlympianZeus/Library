import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookComponent } from './book.component';
import { authGuard, permissionGuard } from '@abp/ng.core';//this is for authentication

const routes: Routes = [{ path: '', component: BookComponent, canActivate: [authGuard, permissionGuard] }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BookRoutingModule { }
