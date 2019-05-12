// -----------------------------------------------------------------------
//  <once-generated>
//     这个文件只生成一次，再次生成不会被覆盖。
//  </once-generated>
//
//  <copyright file="blogs.routing.ts" company="柳柳软件">
//      
//  </copyright>
//  <site></site>
//  <last-editor></last-editor>
// -----------------------------------------------------------------------

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ACLGuard } from '@delon/acl';
import { BlogComponent } from './blog/blog.component';
import { PostComponent } from './post/post.component';

const routes: Routes = [
  { path: 'blog', component: BlogComponent, canActivate: [ACLGuard], data: { title: '博客管理', reuse: true, guard: 'Root.Admin.Blogs.Blog.Read' } },
  { path: 'post', component: PostComponent, canActivate: [ACLGuard], data: { title: '文章管理', reuse: true, guard: 'Root.Admin.Blogs.Post.Read' } },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BlogsRoutingModule { }
