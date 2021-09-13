<template>
    <div class="dx-field-value">
          <DxDropDownButton
            :items="items"
            :drop-down-options="{ width: 230 }"
            text="Tất cả trạng thái"
            @item-click="onItemClick"
          />
    </div>
</template> 
 
<script>
import DxDropDownButton from "devextreme-vue/drop-down-button";
export default {
  components: {
    DxDropDownButton,
  },
  data() {
    return {
      items: ['Tất cả trạng thái', 'Đang theo dõi', 'Ngừng theo dõi roi'],
    };
  },
  methods: {
      onItemClick(e)
      {
          notify(e.itemData.name || e.itemData, 'success', 600);
      }
  },
};
</script>