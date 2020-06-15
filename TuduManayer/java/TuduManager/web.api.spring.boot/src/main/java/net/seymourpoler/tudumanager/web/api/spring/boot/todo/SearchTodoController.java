package net.seymourpoler.tudumanager.web.api.spring.boot.todo;

import net.seymourpoler.tudumanager.domain.todo.search.ISearchTodoService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class SearchTodoController {

    private final ISearchTodoService searchTodoService;

    @Autowired
    public SearchTodoController(ISearchTodoService searchTodoService) {
        this.searchTodoService = searchTodoService;
    }

    @GetMapping("/api/todos")
    public ResponseEntity seach(@RequestParam("searchText") String searchText){
        var todos = searchTodoService.search(searchText);
        return ResponseEntity.ok(todos);
    }
}
