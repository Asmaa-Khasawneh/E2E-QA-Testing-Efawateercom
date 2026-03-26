/*
   Licensed to the Apache Software Foundation (ASF) under one or more
   contributor license agreements.  See the NOTICE file distributed with
   this work for additional information regarding copyright ownership.
   The ASF licenses this file to You under the Apache License, Version 2.0
   (the "License"); you may not use this file except in compliance with
   the License.  You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
var showControllersOnly = false;
var seriesFilter = "";
var filtersOnlySampleSeries = true;

/*
 * Add header in statistics table to group metrics by category
 * format
 *
 */
function summaryTableHeader(header) {
    var newRow = header.insertRow(-1);
    newRow.className = "tablesorter-no-sort";
    var cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 1;
    cell.innerHTML = "Requests";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 3;
    cell.innerHTML = "Executions";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 7;
    cell.innerHTML = "Response Times (ms)";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 1;
    cell.innerHTML = "Throughput";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 2;
    cell.innerHTML = "Network (KB/sec)";
    newRow.appendChild(cell);
}

/*
 * Populates the table identified by id parameter with the specified data and
 * format
 *
 */
function createTable(table, info, formatter, defaultSorts, seriesIndex, headerCreator) {
    var tableRef = table[0];

    // Create header and populate it with data.titles array
    var header = tableRef.createTHead();

    // Call callback is available
    if(headerCreator) {
        headerCreator(header);
    }

    var newRow = header.insertRow(-1);
    for (var index = 0; index < info.titles.length; index++) {
        var cell = document.createElement('th');
        cell.innerHTML = info.titles[index];
        newRow.appendChild(cell);
    }

    var tBody;

    // Create overall body if defined
    if(info.overall){
        tBody = document.createElement('tbody');
        tBody.className = "tablesorter-no-sort";
        tableRef.appendChild(tBody);
        var newRow = tBody.insertRow(-1);
        var data = info.overall.data;
        for(var index=0;index < data.length; index++){
            var cell = newRow.insertCell(-1);
            cell.innerHTML = formatter ? formatter(index, data[index]): data[index];
        }
    }

    // Create regular body
    tBody = document.createElement('tbody');
    tableRef.appendChild(tBody);

    var regexp;
    if(seriesFilter) {
        regexp = new RegExp(seriesFilter, 'i');
    }
    // Populate body with data.items array
    for(var index=0; index < info.items.length; index++){
        var item = info.items[index];
        if((!regexp || filtersOnlySampleSeries && !info.supportsControllersDiscrimination || regexp.test(item.data[seriesIndex]))
                &&
                (!showControllersOnly || !info.supportsControllersDiscrimination || item.isController)){
            if(item.data.length > 0) {
                var newRow = tBody.insertRow(-1);
                for(var col=0; col < item.data.length; col++){
                    var cell = newRow.insertCell(-1);
                    cell.innerHTML = formatter ? formatter(col, item.data[col]) : item.data[col];
                }
            }
        }
    }

    // Add support of columns sort
    table.tablesorter({sortList : defaultSorts});
}

$(document).ready(function() {

    // Customize table sorter default options
    $.extend( $.tablesorter.defaults, {
        theme: 'blue',
        cssInfoBlock: "tablesorter-no-sort",
        widthFixed: true,
        widgets: ['zebra']
    });

    var data = {"OkPercent": 100.0, "KoPercent": 0.0};
    var dataset = [
        {
            "label" : "FAIL",
            "data" : data.KoPercent,
            "color" : "#FF6347"
        },
        {
            "label" : "PASS",
            "data" : data.OkPercent,
            "color" : "#9ACD32"
        }];
    $.plot($("#flot-requests-summary"), dataset, {
        series : {
            pie : {
                show : true,
                radius : 1,
                label : {
                    show : true,
                    radius : 3 / 4,
                    formatter : function(label, series) {
                        return '<div style="font-size:8pt;text-align:center;padding:2px;color:white;">'
                            + label
                            + '<br/>'
                            + Math.round10(series.percent, -2)
                            + '%</div>';
                    },
                    background : {
                        opacity : 0.5,
                        color : '#000'
                    }
                }
            }
        },
        legend : {
            show : true
        }
    });

    // Creates APDEX table
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.9659498207885304, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [1.0, 500, 1500, "https://localhost:44318/api/Billercategory/GetAllBillercategory"], "isController": false}, {"data": [1.0, 500, 1500, "http://localhost:4200/scripts.js"], "isController": false}, {"data": [0.0, 500, 1500, "https://localhost:44318/api/User/UploadImage"], "isController": false}, {"data": [1.0, 500, 1500, "http://localhost:4200/assets/assestR/css/animate.css"], "isController": false}, {"data": [1.0, 500, 1500, "http://localhost:4200/assets/assestR/js/jquery.min.js"], "isController": false}, {"data": [1.0, 500, 1500, "http://localhost:4200/assets/assestR/js/roberto.bundle.js"], "isController": false}, {"data": [1.0, 500, 1500, "https://localhost:44318/api/Login/Loginuser"], "isController": false}, {"data": [1.0, 500, 1500, "https://localhost:44318/api/Testimonial"], "isController": false}, {"data": [1.0, 500, 1500, "http://localhost:4200/assets/assestR/css/bootstrap-datepicker.min.css"], "isController": false}, {"data": [1.0, 500, 1500, "http://localhost:4200/assets/assestR/style.css"], "isController": false}, {"data": [1.0, 500, 1500, "Transaction Controller(Login)"], "isController": true}, {"data": [0.0, 500, 1500, "JDBC Request"], "isController": false}, {"data": [1.0, 500, 1500, "http://localhost:4200/assets/assestR/js/default-assets/active.js"], "isController": false}, {"data": [1.0, 500, 1500, "http://localhost:4200/assets/assestR/css/nice-select.css"], "isController": false}, {"data": [1.0, 500, 1500, "http://localhost:4200/assets/assestR/css/fonts/ElegantIcons.woff"], "isController": false}, {"data": [1.0, 500, 1500, "http://localhost:4200/assets/assestR/js/bootstrap.min.js"], "isController": false}, {"data": [1.0, 500, 1500, "http://localhost:4200/assets/assestR/css/font-awesome.min.css"], "isController": false}, {"data": [1.0, 500, 1500, "http://localhost:4200/assets/assestR/img/core-img/logo22.jpeg"], "isController": false}, {"data": [1.0, 500, 1500, "https://localhost:44318/api/User/Register"], "isController": false}, {"data": [1.0, 500, 1500, "http://localhost:4200/main.js"], "isController": false}, {"data": [1.0, 500, 1500, "http://localhost:4200/styles.js"], "isController": false}, {"data": [1.0, 500, 1500, "http://localhost:4200/assets/assestR/fonts/fontawesome-webfont.woff2?v=4.7.0"], "isController": false}, {"data": [1.0, 500, 1500, "http://localhost:4200/runtime.js"], "isController": false}, {"data": [1.0, 500, 1500, "http://localhost:4200/assets/assestR/css/style.css"], "isController": false}, {"data": [0.0, 500, 1500, "Transaction Controller(Register)"], "isController": true}, {"data": [1.0, 500, 1500, "http://localhost:4200/vendor.js"], "isController": false}, {"data": [1.0, 500, 1500, "http://localhost:4200/assets/assestR/css/default-assets/classy-nav.css"], "isController": false}, {"data": [1.0, 500, 1500, "http://localhost:4200/assets/assestR/img/core-img/favicon.png"], "isController": false}, {"data": [1.0, 500, 1500, "Transaction Controller(changing name)"], "isController": true}, {"data": [0.9848484848484849, 500, 1500, "https://localhost:44318/api/SiteSetting/GetAllSitesetting"], "isController": false}, {"data": [1.0, 500, 1500, "Transaction Controller (Testimonial)"], "isController": true}, {"data": [1.0, 500, 1500, "https://localhost:44318/api/User/GetUserprofile/1025"], "isController": false}, {"data": [1.0, 500, 1500, "Debug Sampler"], "isController": false}, {"data": [1.0, 500, 1500, "http://localhost:4200/styles.css"], "isController": false}, {"data": [1.0, 500, 1500, "http://localhost:4200/assets/assestR/css/magnific-popup.css"], "isController": false}, {"data": [1.0, 500, 1500, "http://localhost:4200/favicon.ico"], "isController": false}, {"data": [1.0, 500, 1500, "http://localhost:4200/assets/assestR/css/bootstrap.min.css"], "isController": false}, {"data": [1.0, 500, 1500, "http://localhost:4200/assets/assestR/css/jquery-ui.min.css"], "isController": false}, {"data": [1.0, 500, 1500, "http://localhost:4200/assets/Images/6cee9894-7106-4425-944a-5bb01c8d3dfe_R.jpg"], "isController": false}, {"data": [1.0, 500, 1500, "http://localhost:4200/auth/reqester"], "isController": false}, {"data": [1.0, 500, 1500, "http://localhost:4200/assets/assestR/css/owl.carousel.min.css"], "isController": false}, {"data": [1.0, 500, 1500, "http://localhost:4200/assets/assestR/js/popper.min.js"], "isController": false}, {"data": [1.0, 500, 1500, "http://localhost:4200/polyfills.js"], "isController": false}]}, function(index, item){
        switch(index){
            case 0:
                item = item.toFixed(3);
                break;
            case 1:
            case 2:
                item = formatDuration(item);
                break;
        }
        return item;
    }, [[0, 0]], 3);

    // Create statistics table
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 258, 0, 0.0, 90.34496124031014, 1, 4451, 5.0, 47.099999999999994, 107.84999999999937, 3998.970000000018, 6.926174496644295, 632.9122797818792, 3.4290320889261743], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["https://localhost:44318/api/Billercategory/GetAllBillercategory", 9, 0, 0.0, 10.666666666666668, 7, 27, 9.0, 27.0, 27.0, 27.0, 0.6929473360024637, 0.6589616376655374, 0.4452727998922082], "isController": false}, {"data": ["http://localhost:4200/scripts.js", 3, 0, 0.0, 21.666666666666668, 19, 27, 19.0, 27.0, 27.0, 27.0, 1.6295491580662682, 1124.6785459668658, 0.5458353136882129], "isController": false}, {"data": ["https://localhost:44318/api/User/UploadImage", 3, 0, 0.0, 4192.666666666667, 3705, 4451, 4422.0, 4451.0, 4451.0, 4451.0, 0.6740058413839587, 0.07569401538980006, 0.6568924118175692], "isController": false}, {"data": ["http://localhost:4200/assets/assestR/css/animate.css", 3, 0, 0.0, 3.3333333333333335, 3, 4, 3.0, 4.0, 4.0, 4.0, 1.6538037486218302, 92.67276650358323, 0.6104861493936052], "isController": false}, {"data": ["http://localhost:4200/assets/assestR/js/jquery.min.js", 3, 0, 0.0, 5.333333333333333, 4, 6, 6.0, 6.0, 6.0, 6.0, 1.644736842105263, 137.93784693667763, 0.5846525493421052], "isController": false}, {"data": ["http://localhost:4200/assets/assestR/js/roberto.bundle.js", 3, 0, 0.0, 5.666666666666667, 5, 7, 5.0, 7.0, 7.0, 7.0, 1.638448935008192, 358.60271026761336, 0.5888175860185692], "isController": false}, {"data": ["https://localhost:44318/api/Login/Loginuser", 3, 0, 0.0, 12.0, 11, 13, 12.0, 13.0, 13.0, 13.0, 103.44827586206897, 42.22790948275862, 72.33297413793103], "isController": false}, {"data": ["https://localhost:44318/api/Testimonial", 9, 0, 0.0, 18.77777777777778, 6, 87, 11.0, 87.0, 87.0, 87.0, 0.7027955645791035, 0.09608533109479932, 0.5017026930735593], "isController": false}, {"data": ["http://localhost:4200/assets/assestR/css/bootstrap-datepicker.min.css", 3, 0, 0.0, 4.0, 3, 5, 4.0, 5.0, 5.0, 5.0, 1.6510731975784259, 25.82542910704458, 0.6368885869565217], "isController": false}, {"data": ["http://localhost:4200/assets/assestR/style.css", 3, 0, 0.0, 4.333333333333333, 4, 5, 4.0, 5.0, 5.0, 5.0, 1.6474464579901154, 117.9356080107084, 0.5984864085667216], "isController": false}, {"data": ["Transaction Controller(Login)", 3, 0, 0.0, 40.666666666666664, 36, 45, 41.0, 45.0, 45.0, 45.0, 66.66666666666667, 117.66493055555556, 181.640625], "isController": true}, {"data": ["JDBC Request", 3, 0, 0.0, 2013.0, 2005, 2019, 2015.0, 2019.0, 2019.0, 2019.0, 1.4858841010401187, 0.017412704309063894, 0.0], "isController": false}, {"data": ["http://localhost:4200/assets/assestR/js/default-assets/active.js", 3, 0, 0.0, 4.0, 4, 4, 4.0, 4.0, 4.0, 4.0, 1.6420361247947455, 15.980988300492612, 0.6013315886699507], "isController": false}, {"data": ["http://localhost:4200/assets/assestR/css/nice-select.css", 3, 0, 0.0, 5.0, 4, 6, 5.0, 6.0, 6.0, 6.0, 1.6538037486218302, 6.930148325523704, 0.6169463202866593], "isController": false}, {"data": ["http://localhost:4200/assets/assestR/css/fonts/ElegantIcons.woff", 3, 0, 0.0, 7.333333333333334, 3, 12, 7.0, 12.0, 12.0, 12.0, 4.0, 249.75, 1.46484375], "isController": false}, {"data": ["http://localhost:4200/assets/assestR/js/bootstrap.min.js", 3, 0, 0.0, 4.666666666666667, 3, 7, 4.0, 7.0, 7.0, 7.0, 1.6348773841961854, 89.52709894414168, 0.5859375], "isController": false}, {"data": ["http://localhost:4200/assets/assestR/css/font-awesome.min.css", 3, 0, 0.0, 3.6666666666666665, 3, 4, 4.0, 4.0, 4.0, 4.0, 1.6519823788546255, 50.409661515693834, 0.6243331841960352], "isController": false}, {"data": ["http://localhost:4200/assets/assestR/img/core-img/logo22.jpeg", 33, 0, 0.0, 5.1818181818181825, 3, 21, 4.0, 8.200000000000003, 12.599999999999966, 21.0, 1.1848341232227488, 3.942013814088755, 0.5567584352111159], "isController": false}, {"data": ["https://localhost:44318/api/User/Register", 3, 0, 0.0, 21.333333333333332, 12, 27, 25.0, 27.0, 27.0, 27.0, 111.1111111111111, 12.47829861111111, 95.48611111111111], "isController": false}, {"data": ["http://localhost:4200/main.js", 3, 0, 0.0, 7.0, 6, 8, 7.0, 8.0, 8.0, 8.0, 1.6411378555798686, 847.9217596074946, 0.5449090536105032], "isController": false}, {"data": ["http://localhost:4200/styles.js", 3, 0, 0.0, 4.0, 4, 4, 4.0, 4.0, 4.0, 4.0, 1.6438356164383563, 287.62467893835617, 0.5490154109589042], "isController": false}, {"data": ["http://localhost:4200/assets/assestR/fonts/fontawesome-webfont.woff2?v=4.7.0", 3, 0, 0.0, 8.666666666666666, 6, 13, 7.0, 13.0, 13.0, 13.0, 4.032258064516129, 304.9158896169355, 1.5239100302419355], "isController": false}, {"data": ["http://localhost:4200/runtime.js", 3, 0, 0.0, 3.3333333333333335, 3, 4, 3.0, 4.0, 4.0, 4.0, 1.6429353778751368, 21.794564622124863, 0.5503191744249726], "isController": false}, {"data": ["http://localhost:4200/assets/assestR/css/style.css", 3, 0, 0.0, 4.333333333333333, 4, 5, 4.0, 5.0, 5.0, 5.0, 1.6510731975784259, 41.152676974408365, 0.6062534397358283], "isController": false}, {"data": ["Transaction Controller(Register)", 3, 0, 0.0, 5035.0, 4105, 5965, 5035.0, 5965.0, 5965.0, 5965.0, 0.4943153732081067, 3843.415790029247, 6.537127718734553], "isController": true}, {"data": ["http://localhost:4200/vendor.js", 3, 0, 0.0, 137.66666666666666, 83, 167, 163.0, 167.0, 167.0, 167.0, 1.5105740181268883, 7552.265270959215, 0.5045081193353474], "isController": false}, {"data": ["http://localhost:4200/assets/assestR/css/default-assets/classy-nav.css", 3, 0, 0.0, 4.333333333333333, 4, 5, 4.0, 5.0, 5.0, 5.0, 1.6519823788546255, 24.784575474944933, 0.6388525605726872], "isController": false}, {"data": ["http://localhost:4200/assets/assestR/img/core-img/favicon.png", 21, 0, 0.0, 4.142857142857142, 3, 8, 4.0, 6.0, 7.799999999999997, 8.0, 0.800152409982854, 0.33856895361021144, 0.3731737592874833], "isController": false}, {"data": ["Transaction Controller(changing name)", 6, 0, 0.0, 218.5, 110, 429, 139.0, 429.0, 429.0, 429.0, 0.5329070077271516, 19.480422606359355, 3.8765862310151875], "isController": true}, {"data": ["https://localhost:44318/api/SiteSetting/GetAllSitesetting", 33, 0, 0.0, 68.12121212121212, 5, 1126, 8.0, 149.8000000000001, 578.5999999999977, 1126.0, 1.138677064283496, 0.7703727226458714, 0.7238039577654325], "isController": false}, {"data": ["Transaction Controller (Testimonial)", 9, 0, 0.0, 79.22222222222223, 40, 203, 45.0, 203.0, 203.0, 203.0, 0.690766751093714, 1.7661172912349374, 2.78128058081971], "isController": true}, {"data": ["https://localhost:44318/api/User/GetUserprofile/1025", 33, 0, 0.0, 25.151515151515152, 4, 143, 6.0, 90.0, 106.59999999999985, 143.0, 2.3096304591265397, 0.2593823269526876, 1.475096015887458], "isController": false}, {"data": ["Debug Sampler", 3, 0, 0.0, 6.333333333333334, 1, 9, 9.0, 9.0, 9.0, 9.0, 62.5, 54.606119791666664, 0.0], "isController": false}, {"data": ["http://localhost:4200/styles.css", 3, 0, 0.0, 5.0, 4, 6, 5.0, 6.0, 6.0, 6.0, 1.6492578339747115, 197.29407899257833, 0.5765960005497526], "isController": false}, {"data": ["http://localhost:4200/assets/assestR/css/magnific-popup.css", 3, 0, 0.0, 4.0, 3, 5, 4.0, 5.0, 5.0, 5.0, 1.6574585635359116, 11.712275552486188, 0.6231655732044199], "isController": false}, {"data": ["http://localhost:4200/favicon.ico", 21, 0, 0.0, 3.5714285714285716, 2, 6, 3.0, 5.0, 5.899999999999999, 6.0, 0.8006405124099278, 0.29376179515040607, 0.35150888567997257], "isController": false}, {"data": ["http://localhost:4200/assets/assestR/css/bootstrap.min.css", 3, 0, 0.0, 4.666666666666667, 4, 5, 5.0, 5.0, 5.0, 5.0, 1.654715940430226, 247.997319704909, 0.6205184776613348], "isController": false}, {"data": ["http://localhost:4200/assets/assestR/css/jquery-ui.min.css", 3, 0, 0.0, 4.0, 3, 5, 4.0, 5.0, 5.0, 5.0, 1.6510731975784259, 27.758668134287287, 0.6191524490919098], "isController": false}, {"data": ["http://localhost:4200/assets/Images/6cee9894-7106-4425-944a-5bb01c8d3dfe_R.jpg", 6, 0, 0.0, 4.0, 3, 5, 4.0, 5.0, 5.0, 5.0, 0.5529953917050692, 18.210235455069125, 0.2575964861751152], "isController": false}, {"data": ["http://localhost:4200/auth/reqester", 3, 0, 0.0, 19.666666666666668, 5, 48, 6.0, 48.0, 48.0, 48.0, 1.6042780748663101, 3.448257854278075, 0.7958723262032085], "isController": false}, {"data": ["http://localhost:4200/assets/assestR/css/owl.carousel.min.css", 3, 0, 0.0, 5.0, 5, 5, 5.0, 5.0, 5.0, 5.0, 1.654715940430226, 5.204921918091561, 0.625366278268064], "isController": false}, {"data": ["http://localhost:4200/assets/assestR/js/popper.min.js", 3, 0, 0.0, 4.0, 4, 4, 4.0, 4.0, 4.0, 4.0, 1.638448935008192, 33.45859929683233, 0.5824173948661934], "isController": false}, {"data": ["http://localhost:4200/polyfills.js", 3, 0, 0.0, 6.333333333333333, 6, 7, 6.0, 7.0, 7.0, 7.0, 1.646542261251372, 494.3871775521405, 0.5547432423161361], "isController": false}]}, function(index, item){
        switch(index){
            // Errors pct
            case 3:
                item = item.toFixed(2) + '%';
                break;
            // Mean
            case 4:
            // Mean
            case 7:
            // Median
            case 8:
            // Percentile 1
            case 9:
            // Percentile 2
            case 10:
            // Percentile 3
            case 11:
            // Throughput
            case 12:
            // Kbytes/s
            case 13:
            // Sent Kbytes/s
                item = item.toFixed(2);
                break;
        }
        return item;
    }, [[0, 0]], 0, summaryTableHeader);

    // Create error table
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": []}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 258, 0, "", "", "", "", "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
