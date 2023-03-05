import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http'
import {catchError, Observable, throwError} from 'rxjs'
import {TokenService} from '../services/token.service'
import {Injectable} from '@angular/core'

@Injectable()
export class AuthInterseptor implements HttpInterceptor {
  constructor(private tokenService: TokenService) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const token = this.tokenService.GetJwtFromCookie()
    req = req.clone({
      setHeaders: {
        Authorization: token,
      },
    })
    return next.handle(req).pipe(
      catchError((error) => {
        return this.handleResponseError(error, req, next)
      })
    )
  }

  handleResponseError(
    error: any,
    request: HttpRequest<any>,
    next: HttpHandler
  ) {
    if (error.status == 401) {
      this.tokenService.SendRefreshToken()
      next.handle(request)
    }
    return throwError(error)
  }
}
