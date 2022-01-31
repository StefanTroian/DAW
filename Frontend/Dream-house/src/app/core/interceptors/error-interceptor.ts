import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { tap } from "rxjs/operators";

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle((req)).pipe(tap(() => {

        }, (error => {
            if (error instanceof HttpErrorResponse) {
                if (error.status == 401) {
                    // toaster shows not allowed
                    // logout user
                }
                if (error.status == 500) {
                    console.error('Server error')
                }
            }
        })))
    }
}
