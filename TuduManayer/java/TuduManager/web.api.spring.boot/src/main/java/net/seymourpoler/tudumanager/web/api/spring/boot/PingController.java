package net.seymourpoler.tudumanager.web.api.spring.boot;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class PingController {

    @GetMapping("/api/ping")
    public ResponseEntity ping(){
        return ResponseEntity.ok("PONG");
    }
}
