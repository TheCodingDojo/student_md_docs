# Angular Post on `(submit)` With `fetch` from component
- ``` js
      window.fetch('/api/tasks', {
        method: 'post',
        headers {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(this.newTask)
      })
        .then(res => res.json())
        .then(data => {
          this.tasks.push(data.task);

          // clear form inputs
          this.newTask = {
            title: '',
            description: '',
            completed: false
          }
        })
        .catch(console.log);
    ```