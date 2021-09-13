<template>
  <div class="menu flex">
    <div class="title-menu flex">
      <div class="icon-toggle"></div>
      <div class="img-title">
        <img
          src="data:image/svg+xml;base64,PHN2ZyBpZD0iR3JvdXBfNDQwNDEiIGRhdGEtbmFtZT0iR3JvdXAgNDQwNDEiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgeG1sbnM6eGxpbms9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkveGxpbmsiIHdpZHRoPSIzNiIgaGVpZ2h0PSIzNiIgdmlld0JveD0iMCAwIDM2IDM2Ij4NCiAgPGRlZnM+DQogICAgPGxpbmVhckdyYWRpZW50IGlkPSJsaW5lYXItZ3JhZGllbnQiIHgxPSIwLjUiIHgyPSIwLjUiIHkyPSIxIiBncmFkaWVudFVuaXRzPSJvYmplY3RCb3VuZGluZ0JveCI+DQogICAgICA8c3RvcCBvZmZzZXQ9IjAiIHN0b3AtY29sb3I9IiM1MGI4M2MiLz4NCiAgICAgIDxzdG9wIG9mZnNldD0iMSIgc3RvcC1jb2xvcj0iIzAxYTM4YSIvPg0KICAgIDwvbGluZWFyR3JhZGllbnQ+DQogICAgPGZpbHRlciBpZD0iUGF0aF8zMzc3NCIgeD0iOC45NCIgeT0iNS42MiIgd2lkdGg9IjE5LjkyIiBoZWlnaHQ9IjI4LjM4IiBmaWx0ZXJVbml0cz0idXNlclNwYWNlT25Vc2UiPg0KICAgICAgPGZlT2Zmc2V0IGR5PSIxIiBpbnB1dD0iU291cmNlQWxwaGEiLz4NCiAgICAgIDxmZUdhdXNzaWFuQmx1ciBzdGREZXZpYXRpb249IjAuNSIgcmVzdWx0PSJibHVyIi8+DQogICAgICA8ZmVGbG9vZCBmbG9vZC1vcGFjaXR5PSIwLjE2MSIvPg0KICAgICAgPGZlQ29tcG9zaXRlIG9wZXJhdG9yPSJpbiIgaW4yPSJibHVyIi8+DQogICAgICA8ZmVDb21wb3NpdGUgaW49IlNvdXJjZUdyYXBoaWMiLz4NCiAgICA8L2ZpbHRlcj4NCiAgPC9kZWZzPg0KICA8ZyBpZD0iR3JvdXBfMzAyMjAiIGRhdGEtbmFtZT0iR3JvdXAgMzAyMjAiPg0KICAgIDxwYXRoIGlkPSJBcHBfSWNvbl9NYXNrLTIiIGRhdGEtbmFtZT0iQXBwIEljb24gTWFzay0yIiBkPSJNMTE5Ni42LDI0MDkuMjU5YzAtLjQzMiwwLS44NiwwLTEuMjksMC0uMzYtLjAwNy0uNzI0LS4wMTYtMS4wODZhMTUuODQ3LDE1Ljg0NywwLDAsMC0uMjA4LTIuMzY0LDcuOTc1LDcuOTc1LDAsMCwwLS43NDEtMi4yNDksNy41NjMsNy41NjMsMCwwLDAtMy4zMDYtMy4zMDYsNy45ODQsNy45ODQsMCwwLDAtMi4yNDctLjc0LDE1Ljg2NiwxNS44NjYsMCwwLDAtMi4zNjUtLjIwOGMtLjM2My0uMDEtLjcyNC0uMDE0LTEuMDg3LS4wMTYtLjQyOSwwLS44NTksMC0xLjI5LDBoLTEzLjQ3N2MtLjQzLDAtLjg2LDAtMS4yOSwwLS4zNjMsMC0uNzI1LjAwNy0xLjA4Ni4wMTZhMTUuODU5LDE1Ljg1OSwwLDAsMC0yLjM2NS4yMDgsNy45OCw3Ljk4LDAsMCwwLTIuMjQ3Ljc0LDcuNTU5LDcuNTU5LDAsMCwwLTMuMzA2LDMuMzA2LDcuOTUsNy45NSwwLDAsMC0uNzQxLDIuMjQ4LDE1Ljc3OCwxNS43NzgsMCwwLDAtLjIwOCwyLjM2NXEtLjAxNC41NDMtLjAxNiwxLjA4N2MwLC40MywwLC44NTksMCwxLjI5djEzLjQ3N2MwLC40MywwLC44NTksMCwxLjI5cTAsLjU0My4wMTYsMS4wODZhMTUuNzg0LDE1Ljc4NCwwLDAsMCwuMjA4LDIuMzY1LDcuOTYsNy45NiwwLDAsMCwuNzQxLDIuMjQ5LDcuNTY4LDcuNTY4LDAsMCwwLDMuMzA2LDMuMyw3Ljk1Nyw3Ljk1NywwLDAsMCwyLjI0Ny43NCwxNS43MywxNS43MywwLDAsMCwyLjM2NS4yMDhjLjM2LjAxLjcyNC4wMTQsMS4wODYuMDE2LjQzLDAsLjg2LDAsMS4yOSwwaDEzLjQ3N2MuNDMsMCwuODYsMCwxLjI5LDAsLjM2MiwwLC43MjQtLjAwNiwxLjA4Ni0uMDE2YTE1LjczNywxNS43MzcsMCwwLDAsMi4zNjUtLjIwOCw3Ljk2Myw3Ljk2MywwLDAsMCwyLjI0Ny0uNzQsNy41NzIsNy41NzIsMCwwLDAsMy4zMDYtMy4zLDcuOTg0LDcuOTg0LDAsMCwwLC43NDEtMi4yNDksMTUuODU0LDE1Ljg1NCwwLDAsMCwuMjA4LTIuMzY1Yy4wMS0uMzYyLjAxNC0uNzI0LjAxNi0xLjA4NiwwLS40MywwLS44NiwwLTEuMjlaIiB0cmFuc2Zvcm09InRyYW5zbGF0ZSgtMTE2MC42MDMgLTIzOTcuOTk3KSIgZmlsbD0idXJsKCNsaW5lYXItZ3JhZGllbnQpIi8+DQogIDwvZz4NCiAgPGcgaWQ9Ikdyb3VwXzMwMjIxIiBkYXRhLW5hbWU9Ikdyb3VwIDMwMjIxIiB0cmFuc2Zvcm09InRyYW5zbGF0ZSgxMC40NCA2LjEyKSI+DQogICAgPGcgdHJhbnNmb3JtPSJtYXRyaXgoMSwgMCwgMCwgMSwgLTEwLjQ0LCAtNi4xMikiIGZpbHRlcj0idXJsKCNQYXRoXzMzNzc0KSI+DQogICAgICA8cGF0aCBpZD0iUGF0aF8zMzc3NC0yIiBkYXRhLW5hbWU9IlBhdGggMzM3NzQiIGQ9Ik0xMzUzLjQ2LDI0MzBhOC40NzYsOC40NzYsMCwwLDAtOC40MzYsNy45OWMtLjAwOS4xNTYtLjAyNC4zMTEtLjAyNC40N3YxNi45MTloMS43NDVhMy45LDMuOSwwLDAsMCwzLjktMy45di01LjA1N2gwdi03Ljk2OGEyLjgxOCwyLjgxOCwwLDEsMSwxLjU1OSwyLjUyM3Y1Ljg0YTguMjg2LDguMjg2LDAsMCwwLDEuMDY5LjA5NWwuMTkyLDAsLjIxOCwwLC4yMTctLjAwOGMuMDcyLDAsLjE0NC0uMDA4LjIxNi0uMDE0YTguNDYxLDguNDYxLDAsMCwwLDcuNzg0LTcuNzg0Yy4wMDYtLjA3Mi4wMS0uMTQ0LjAxNC0uMjE2cy4wMDYtLjE0NS4wMDgtLjIxNywwLS4xNDUsMC0uMjE4QTguNDYsOC40NiwwLDAsMCwxMzUzLjQ2LDI0MzBaIiB0cmFuc2Zvcm09InRyYW5zbGF0ZSgtMTMzNC41NiAtMjQyMy44OCkiIGZpbGw9IiNmZmYiLz4NCiAgICA8L2c+DQogICAgPHBhdGggaWQ9IlBhdGhfMzM3NzUiIGRhdGEtbmFtZT0iUGF0aCAzMzc3NSIgZD0iTTEzNjkuMDc5LDI0NTMuNWEyLjgyLDIuODIsMCwwLDEtNC4wODEsMi41MjN2NS44NGE4LjI4NCw4LjI4NCwwLDAsMCwxLjA2OS4wOTRsLjE5MiwwYy4wNzMsMCwuMTQ2LDAsLjIxOCwwcy4xNDUsMCwuMjE3LS4wMDguMTQ0LS4wMDguMjE2LS4wMTRhOC40Niw4LjQ2LDAsMCwwLDcuNzg0LTcuNzg0Yy4wMDYtLjA3Mi4wMS0uMTQ0LjAxNC0uMjE2cy4wMDYtLjE0NS4wMDgtLjIxNywwLS4xNDUsMC0uMjE4WiIgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoLTEzNTcuNzk5IC0yNDQ1LjA0KSIgZmlsbD0iI2ZmZiIvPg0KICA8L2c+DQo8L3N2Zz4NCg=="
          alt="logo"
          width="32"
          height="32"
        />
      </div>
      <div class="text-title">Tiền lương</div>
    </div>
    <div class="navbar flex">
      <ul>
        <div class="nav-item">
          <div class="nav-item-text fs-14"><span>Tổng quan</span></div>
        </div>
        <div class="nav-item">
          <div class="nav-item-text fs-14">
            <span class="item-active">Thành phần lương</span>
          </div>
        </div>
        <div class="nav-item flex">
          <div class="nav-item-text flex fs-13">
            <span>Chính sách</span>
            <div class="icon-menu"><i class="fas fa-chevron-down"></i></div>
          </div>
        </div>
        <div class="nav-item flex">
          <div class="nav-item-text flex fs-13">
            <span>Dữ liệu tính lương</span>
            <div class="icon-menu"><i class="fas fa-chevron-down"></i></div>
          </div>
        </div>
        <div class="nav-item flex">
          <div class="nav-item-text flex fs-13">
            <span>Tính lương</span>
            <div class="icon-menu"><i class="fas fa-chevron-down"></i></div>
          </div>
        </div>
        <div class="nav-item">
          <div class="nav-item-text fs-14"><span>Chi trả lương</span></div>
        </div>
        <div class="nav-item flex">
          <div class="nav-item-text flex fs-13">
            <span>Báo cáo</span>
            <div class="icon-menu"><i class="fas fa-chevron-down"></i></div>
          </div>
        </div>
      </ul>
    </div>
    <div class="menu-right flex">
        <div class="box-icon-setting">
            <div class="icon-setting" title="Thiết lập"></div>
        </div>
        <div class="box-icon-bell">
            <div class="icon-bell" title="Thông báo"></div>
        </div>
      <div class="box-icon-help">
        <div class="icon-help" title="Giúp đỡ"></div>
      </div>
      <div class="box-item-more">
        <div class="icon-more" title="Tính năng khác"></div>
      </div>
      <div class="img-menu-right"></div>
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style>
</style>