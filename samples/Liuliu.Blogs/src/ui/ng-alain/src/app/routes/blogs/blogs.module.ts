// -----------------------------------------------------------------------
//  <once-generated>
//     这个文件只生成一次，再次生成不会被覆盖。
//  </once-generated>
//
//  <copyright file="blogs.module.ts" company="柳柳软件">
//      
//  </copyright>
//  <site></site>
//  <last-editor></last-editor>
// -----------------------------------------------------------------------

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '@shared';
import { BlogsRoutingModule } from './blogs.routing';
import { BlogComponent } from './blog/blog.component';
import { PostComponent } from './post/post.component';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    BlogsRoutingModule
  ],
  declarations: [
    BlogComponent,
    PostComponent,
  ]
})
export class BlogsModule { }
