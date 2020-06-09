import { HttpStatusCode } from '../../HttpStatusCode';
import { Http, createHttp } from '../../Http';
import { spyAllMethodsOf } from '../../Testing';
import { SearchTodoService } from './SearchTodoService';

describe('Search Todo Service', () =>{
	let service, http;

	beforeEach(() => {
		http = createHttp();
		spyAllMethodsOf(http);
		service = new SearchTodoService(http);
	});
	
	it('returns error if there is an internal server error',  async () => {
		const text = 'a text';
        http.get = () => {return {statusCode: HttpStatusCode.internalServerError }};

        const result = await service.search();
		
        expect(result.statusCode).toBe(HttpStatusCode.internalServerError);
	});
});
