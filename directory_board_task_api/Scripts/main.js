function loadDirectoryData() {
  $.getJSON('http://localhost:49719/api/directories', function(directoryData) {
    // Detect Chrome Browser to Hide the Warning Message & Activate the Drag & Drop
    if (
      /chrom(e|ium)/.test(navigator.userAgent.toLowerCase()) &&
      !/edge/.test(navigator.userAgent.toLowerCase())
    ) {
      $('.dropbox-container').hide();
      BindTable(directoryData);
      BindEditable(directoryData);

      $('#fixedtable tr').fadeIn(1500);
      // Go Into FullScreen Mode
      //goInFullScreen(document.body);
    } else {
      $('.warning-message').text(
        'This site is optimized for Google Chrome Browser! Please follow this link to the <a href="https://www.google.com/chrome/" target="_blank">Download</a> and reopen the site in Chrome.'
      );
      $('.center-message').text('Please open the page with Chrome browser!');
      $('.dropbox-container').show();
    }
  });
    loadLogData();
}

function BindEditable(jsondata) {
  // Get all the column headings of the data
  var columns = BindEditableHeaderEl(jsondata);
  var colEds = GetEditableColumnsEd(columns);
  BindEditableEl(jsondata, columns);
  $('#makeEditable').SetEditable({
    columnsEd: colEds,
    $addButton: $('#but_add'),
    onEdit: function(a) {
      var row$ = a.children();
      if ($(row$[0]).text() === '') {
        createRecord({
          company: $(row$[1]).text(),
          level: $(row$[2]).text(),
          suite: $(row$[3]).text(),
        });
      } else {
        editRecord({
          id: $(row$[0]).text(),
          company: $(row$[1]).text(),
          level: $(row$[2]).text(),
          suite: $(row$[3]).text(),
        });
      }
    }, //Called after edition
    onBeforeDelete: function(a) {
      deletingEdItem = false;
      if (confirm('Are you sure you want to delete this data?')) {
        var row$ = a.children();
        deleteRecord($(row$[0]).text());
      } else {
        return 'cancel';
      }
    }, //Called before deletion
  });
}
function GetEditableColumnsEd(columns) {
  var colEds = '';
  for (var i = 0; i < columns.length; i++) {
    if (columns[i] !== 'Id') {
      colEds += i + (i < columns.length - 1 ? ',' : '');
    }
  }
  return colEds;
}
function BindEditableHeaderEl(jsondata) {
  var columns = [];
  var row$ = $('<tr/>');
  for (var i = 0; i < jsondata.length; i++) {
    var rowHash = jsondata[i];
    for (var key in rowHash) {
      if (rowHash.hasOwnProperty(key)) {
        // Add each unique column names to a variable array*/
        if ($.inArray(key, columns) === -1) {
          columns.push(key);
          row$.append(
            $('<th ' + (key === 'Id' ? 'class="hidden"' : '') + '/>').html(key)
          );
        }
      }
    }
  }
  $('#makeEditable thead').empty();
  $('#makeEditable thead').append(row$);
  return columns;
}
function BindEditableEl(jsondata, columns) {
  $('#makeEditable tbody').empty();
  for (var i = 0; i < jsondata.length; i++) {
    var row$ = $('<tr/>');
    for (var j = 0; j < columns.length; j++) {
      var key = columns[j];
      var val = jsondata[i][key];
      row$.append(
        $('<td ' + (key === 'Id' ? 'class="hidden"' : '') + '/>').html(
          val === null ? '' : val
        )
      );
    }
    $('#makeEditable tbody').append(row$);
  }
}

function loadLogData() {
  $.getJSON('http://localhost:49719/api/logs', function(jsondata) {
    $('#logTable').empty();
    // Get all the column headings of the data
    var columns = BindLogTableHeader(jsondata, '#logTable');
    for (var i = 0; i < jsondata.length; i++) {
      var row$ = $('<tr/>');
      for (var colIndex = 0; colIndex < columns.length; colIndex++) {
        var cellValue = jsondata[i][columns[colIndex]];
        if (cellValue == null) cellValue = '';
        row$.append($('<td/>').html(cellValue));
      }
      $('#logTable').append(row$);
    }
  });
}
// Bind log table header
function BindLogTableHeader(jsondata, tableid) {
  var columnSet = [];
  var headerTr$ = $('<tr/>');
  for (var i = 0; i < jsondata.length; i++) {
    var rowHash = jsondata[i];
    for (var key in rowHash) {
      if (rowHash.hasOwnProperty(key)) {
        // Add each unique column names to a variable array*/
          if (key !== 'Id' && key !== 'DirectoryId') {
              if ($.inArray(key, columnSet) === -1) {
                  columnSet.push(key);
                  headerTr$.append($('<th/>').html(key));
              }
          }
      }
    }
  }
  $(tableid + 'tr').remove();
  $(tableid).append(headerTr$);
  return columnSet;
}

function createRecord(data) {
  $.ajax({
    url: 'http://localhost:49719/api/directories/',
    type: 'POST',
    data: data,
    success: function(res) {
      loadDirectoryData();
    },
  });
}
// EDIT AJAX call
function editRecord(data) {
  $.ajax({
    url: 'http://localhost:49719/api/directories/',
    type: 'PUT',
    data: data,
    success: function(res) {
      loadDirectoryData();
    },
    error: function(err) {
      alert('A server error has occured :(');
    },
  });
}
// DELETE AJAX call
function deleteRecord(id) {
  $.ajax({
    url: 'http://localhost:49719/api/directories/' + id,
    type: 'DELETE',
    data: id,
    success: function(res) {
      loadDirectoryData();
    },
    error: function(err) {
      alert('A server error has occured :(');
    },
  });
}

// Convert the JSON array to Html Table
function BindTable(jsondata) {
  var tableid = '#table-1, #table-2';
  // Get all the column headings of the data
  var columns = BindTableHeader(jsondata, tableid);
  for (var i = 0; i < jsondata.length; i++) {
    var row$ = $('<tr/>');
    for (var colIndex = 0; colIndex < columns.length; colIndex++) {
      var cellValue = jsondata[i][columns[colIndex]];
      if (cellValue == null) cellValue = '';
      row$.append($('<td/>').html(cellValue));
    }
    $(tableid).append(row$);
  }
  // Append the "..." to the First Column of the HTML Table
  $('.table-display tr td:nth-child(2)').append(
    '       . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . '
  );
  $(tableid).show();
}

// Get all Column Names from JSON and Bind the HTML Table Header
function BindTableHeader(jsondata, tableid) {
  var columnSet = [];
  var headerTr$ = $('<tr/>');
  for (var i = 0; i < jsondata.length; i++) {
    var rowHash = jsondata[i];
    for (var key in rowHash) {
      if (rowHash.hasOwnProperty(key)) {
        // Add each unique column names to a variable array*/
        if ($.inArray(key, columnSet) === -1) {
          columnSet.push(key);
          headerTr$.append($('<th/>').html(key));
        }
      }
    }
  }
  $('#table-1 tr, #table-2 tr').remove();
  $(tableid).append(headerTr$);
  return columnSet;
}

function goInFullScreen(element) {
  //enter full screen mode
  if (element.requestFullscreen) element.requestFullscreen();
  else if (element.mozRequestFullScreen) element.mozRequestFullScreen();
  else if (element.webkitRequestFullscreen) element.webkitRequestFullscreen();
  else if (element.msRequestFullscreen) element.msRequestFullscreen();
  //hide cursor, too
  document.body.style.cursor = 'none';
}

/* Open editor modal */
(function() {
  $('#modal-open').click(function() {
    $('#modal-overlay')
      .fadeIn(200)
      .css('display', 'flex');
  });
  $('#modal-overlay-hide').click(function() {
    $('#modal-overlay').fadeOut(200);
  });
  var timedelay = 1;

  function delayCheck() {
    if (timedelay == 5) {
      $('#modal-open').fadeOut();
      timedelay = 1;
    }
    timedelay = timedelay + 1;
  }

  /* Show editor button */
  $(document).mousemove(function() {
    $('#modal-open').fadeIn();
    timedelay = 1;
    clearInterval(_delay);
    _delay = setInterval(delayCheck, 200);
  });
  // page loads starts delay timer
  _delay = setInterval(delayCheck, 200);
})();

// Starting
$(document).ready(function() {
  loadDirectoryData();
  // tabs
  $('#nav-tab a').on('click', function(e) {
    e.preventDefault();
    $(this).tab('show');
  });
});
