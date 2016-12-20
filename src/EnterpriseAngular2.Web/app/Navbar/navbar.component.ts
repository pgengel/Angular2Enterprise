import {Component} from 'angular2/core';

import {ContactFormComponent} from '../Contact/contact-form.component'

/// <reference path="../typings/tsd.d.ts" />
import { Observable } from 'rxjs/Observable'
import 'rxjs/add/operator/debounceTime'
import 'rxjs/add/operator/filter'
import { PostService } from '../Services/HttpPost/post.service'
import { HTTP_PROVIDERS } from 'angular2/http'
import { OnInit } from 'angular2/core'

import { RouteConfig, ROUTER_DIRECTIVES, Router } from 'angular2/router'
import { AlbumsComponent } from '../Albums/albums.component'
import { ContactComponent } from '../Contact/contact.component'




@RouteConfig([
    {path: '/albums', name: 'Albums', component: AlbumsComponent, useAsDefault: true},
    {path: '/album/:id', name: 'Album', component: AlbumsComponent},
    {path: '/contact', name: 'Contact', component: ContactComponent},
    {path: '/*other', name: 'Other', redirectTo: ['Albums']}
])

@Component({
    selector: 'navbar',
    templateUrl: 'app/Navbar/navbar.component.html',
    directives: [NavBarComponent,
                 ROUTER_DIRECTIVES],
    providers: [PostService, HTTP_PROVIDERS]
})
export class NavBarComponent{
    albumsActive = true;
    contactActive = false; 

    constructor(private _router: Router){
     }

      isCurrentRoute(route){
         var instruction = this._router.generate(route);
         return this._router.isRouteActive(instruction);
     }
    //constructor(private _postService: PostService){
        //this._postService.createPost({userId: 1, title: 'a', body: "b"});
    //}

    ngOnInit(){
            // this._postService.getPosts()
            // .subscribe(post => {
            //     console.log(post[0].title);
            //     this.isLoading = false;
            // });  
    }
}